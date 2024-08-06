using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.RectTransform;
using static UnityEngine.UI.ContentSizeFitter;

namespace Client.Code.Common.UI.Layout
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    public class CustomContentSizeFitter : UIBehaviour, ILayoutSelfController
    {
        [SerializeField] private FitMode _horizontalFitting;
        [SerializeField] private FitMode _verticalFitting;
        private DrivenRectTransformTracker _tracker;
        private RectTransform _rect;

        protected override void OnEnable()
        {
            base.OnEnable();
            SetDirty();
        }

        protected override void OnDisable()
        {
            _tracker.Clear();
            LayoutRebuilder.MarkLayoutForRebuild(GetRect());
            base.OnDisable();
        }

        protected override void OnRectTransformDimensionsChange() => SetDirty();

#if UNITY_EDITOR
        protected override void OnValidate() => SetDirty();
#endif

        public void SetLayoutHorizontal() => HandleFittingAlongAxis(Axis.Horizontal);

        public void SetLayoutVertical() => HandleFittingAlongAxis(Axis.Vertical);

        private void HandleFittingAlongAxis(Axis axis)
        {
            var fitting = axis == Axis.Horizontal ? _horizontalFitting : _verticalFitting;
            var rect = GetRect();

            HandleTracker(axis, fitting, rect);

            if (fitting == FitMode.Unconstrained)
                return;

            if (fitting == FitMode.MinSize)
                rect.SetSizeWithCurrentAnchors(axis, LayoutUtility.GetMinSize(rect, (int)axis));
            else
                rect.SetSizeWithCurrentAnchors(axis, LayoutUtility.GetPreferredSize(rect, (int)axis));
        }

        private void HandleTracker(Axis axis, FitMode fitting, RectTransform rect)
        {
            _tracker.Clear();

            if (fitting == FitMode.Unconstrained)
            {
                _tracker.Add(this, rect, DrivenTransformProperties.None);
                return;
            }

            var drivenProperties = axis == Axis.Horizontal
                ? DrivenTransformProperties.SizeDeltaX
                : DrivenTransformProperties.SizeDeltaY;
            _tracker.Add(this, rect, drivenProperties);
        }

        private void SetDirty()
        {
            if (!IsActive())
                return;

            var rect = GetRect();
            if (!CanvasUpdateRegistry.IsRebuildingLayout())
                LayoutRebuilder.MarkLayoutForRebuild(rect);
            else
                StartCoroutine(DelayedSetDirty(rect));
        }

        private IEnumerator DelayedSetDirty(RectTransform rectTransform)
        {
            yield return null;
            LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
        }

        private RectTransform GetRect()
        {
            if (!_rect)
                _rect = gameObject.GetComponent<RectTransform>();

            return _rect;
        }
    }
}