using Client.Code.Common.Services.Unity;
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

        protected override void OnEnable() => SetDirty();

        protected override void OnDisable()
        {
            _tracker.Clear();
            LayoutRebuilder.MarkLayoutForRebuild(GetRect());
        }

#if UNITY_EDITOR
        protected override void OnValidate() => SetDirty();
#endif

        protected override void OnRectTransformDimensionsChange() => SetDirty();

        public void SetLayoutHorizontal() => HandleFittingAlongAxis(Axis.Horizontal);

        public void SetLayoutVertical() => HandleFittingAlongAxis(Axis.Vertical);

        private RectTransform GetRect()
        {
            if (!_rect)
                _rect = gameObject.GetComponent<RectTransform>();

            return _rect;
        }

        private void SetDirty()
        {
            if (IsActive())
                UILayoutTools.SetDirty(GetRect());
        }

        private void HandleFittingAlongAxis(Axis axis)
        {
            var fitting = axis == Axis.Horizontal ? _horizontalFitting : _verticalFitting;
            var rect = GetRect();

            if (fitting == FitMode.Unconstrained)
                return;

            if (fitting == FitMode.MinSize)
                rect.SetSizeWithCurrentAnchors(axis, LayoutUtility.GetMinSize(rect, (int)axis));
            else
                rect.SetSizeWithCurrentAnchors(axis, LayoutUtility.GetPreferredSize(rect, (int)axis));
            
            if (PlatformsConstants.IsEditor)
                HandleTracker(axis, fitting, rect);
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
    }
}