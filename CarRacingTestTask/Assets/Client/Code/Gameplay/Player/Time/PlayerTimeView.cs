using System.Globalization;
using Client.Code.Utilities;
using TMPro;
using UnityEngine;

namespace Client.Code.Gameplay.Player.Time
{
    public class PlayerTimeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void SetTime(float value)
        {
            var text = MathfExtensions.Round(value, 2).ToString(CultureInfo.InvariantCulture);
            _text.SetText(text);
        }
    }
}