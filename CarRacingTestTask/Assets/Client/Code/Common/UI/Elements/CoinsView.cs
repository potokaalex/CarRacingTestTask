using TMPro;
using UnityEngine;

namespace Client.Code.Common.UI
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;

        public void Initialize(int coinsCount) => SetCoinsCount(coinsCount);

        public void SetCoinsCount(int value) => _coinsText.SetText(value.ToString());
    }
}