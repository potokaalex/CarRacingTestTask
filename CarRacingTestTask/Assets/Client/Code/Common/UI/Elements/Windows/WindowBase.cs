using UnityEngine;

namespace Client.Code.Common.UI.Elements.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        public abstract WindowType GetBaseType();

        public void Open() => gameObject.SetActive(true);

        public void Close() => gameObject.SetActive(false);
    }
}