using System.Globalization;
using Client.Code.Utilities;
using TMPro;
using UnityEngine;

namespace Client.Code.Gameplay.Player.Time
{
    public class PlayerTimeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void SetTime(float valueMs)
        {
            var sec = valueMs / 1000;
            var ms = valueMs % 1000 / 10;
            var text = $"{(int)sec:D2}:{(int)ms:D2}";
            _text.SetText(text.ToString(CultureInfo.InvariantCulture));
        }
    }
}