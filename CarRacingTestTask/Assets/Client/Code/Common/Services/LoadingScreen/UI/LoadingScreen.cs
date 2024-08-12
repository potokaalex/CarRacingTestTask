using Client.Code.Common.UI.Elements.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Code.Common.Services.LoadingScreen.UI
{
    public class LoadingScreen : WindowBase, ILoadingScreen
    {
        [SerializeField] private Slider _slider;

        public void Initialize() => _slider.value = 0;

        public void SetProgress(float value, float startValue, float endValue) => _slider.value = Mathf.Lerp(startValue, endValue, value);

        public override WindowType GetBaseType() => WindowType.None;
    }
}