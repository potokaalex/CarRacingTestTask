using Client.Code.Common.Services.Unity;
using UnityEngine;

namespace Client.Code.Common.UI.Layout
{
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaFitter : MonoBehaviour
    {
        private DrivenRectTransformTracker _tracker;
        private RectTransform _rect;
        private Rect _safeArea;
        private Vector2 _screenSize;

        private void Update() => Fit();

        private void OnEnable()
        {
            _tracker.Clear();
            _tracker.Add(this, GetRect(), DrivenTransformProperties.Anchors);
        }

        private void OnDisable() => _tracker.Clear();

        private void Fit()
        {
            if (!IsScreenSizeChanged() && !IsSafeAreaChanged())
                return;

            var anchorMin = _safeArea.position;
            var anchorMax = anchorMin + _safeArea.size;
            var rect = GetRect();

            rect.anchorMin = anchorMin / _screenSize;
            rect.anchorMax = anchorMax / _screenSize;

            if (PlatformsConstants.IsEditor)
                HandleTracker(rect);
        }

        private bool IsSafeAreaChanged()
        {
            var safeArea = Screen.safeArea;

            if (_safeArea == safeArea)
                return false;

            _safeArea = safeArea;
            return true;
        }

        private bool IsScreenSizeChanged()
        {
            var screenSize = new Vector2(Screen.width, Screen.height);

            if (_screenSize == screenSize)
                return false;

            _screenSize = screenSize;
            return true;
        }

        private void HandleTracker(RectTransform rect)
        {
            _tracker.Clear();
            _tracker.Add(this, rect, DrivenTransformProperties.Anchors);
        }

        private RectTransform GetRect()
        {
            if (!_rect)
                _rect = gameObject.GetComponent<RectTransform>();

            return _rect;
        }
    }
}