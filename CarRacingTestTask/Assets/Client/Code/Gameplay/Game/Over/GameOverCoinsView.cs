using TMPro;
using UnityEngine;

namespace Client.Code.Gameplay.Game.Over
{
    public class GameOverCoinsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;

        public void Initialize(int coinsCount) => SetCoinsCount(coinsCount);

        public void SetCoinsCount(int value) => _coinsText.SetText(value.ToString());
    }
}