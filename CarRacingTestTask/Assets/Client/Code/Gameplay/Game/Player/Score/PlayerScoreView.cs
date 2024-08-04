using System.Globalization;
using Client.Code.Common.Utilities;
using TMPro;
using UnityEngine;

namespace Client.Code.Gameplay.Game.Player.Score
{
    public class PlayerScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void SetScore(float value)
        {
            var text = MathfExtensions.Round(value, 3).ToString(CultureInfo.InvariantCulture);
            _text.SetText(text);
        }
    }
}