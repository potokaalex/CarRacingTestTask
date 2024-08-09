using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Code.Common.UI.Layout
{
    public static class UILayoutTools
    {
        public static void SetDirty(RectTransform rect) => SetDirtyAsync(rect).Forget();

        private static async UniTaskVoid SetDirtyAsync(RectTransform rect)
        {
            if (CanvasUpdateRegistry.IsRebuildingLayout())
            {
                await UniTask.Yield();
                LayoutRebuilder.MarkLayoutForRebuild(rect);
            }
            else
                LayoutRebuilder.MarkLayoutForRebuild(rect);
        }
    }
}