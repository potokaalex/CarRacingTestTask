using System.Collections.Generic;
using Client.Code.Common.Data;
using UnityEngine;
using Zenject;

namespace Client.Code.Common.UI.Dropdowns.Car
{
    public class CarColorDropdown : DropdownBase
    {
        [SerializeField] private Dictionary<int, CarColorType> _colors;
        private ICarColorDropdownHandler _handler;

        [Inject]
        public void Construct(ICarColorDropdownHandler handler) => _handler = handler;

        public void Set(CarColorType color)
        {
            var i = 0;

            foreach (var pair in _colors)
                if (pair.Value == color)
                    i = pair.Key;

            BaseDropdown.SetValueWithoutNotify(i);
        }

        private protected override void OnValueChanged(int elementNumber) => _handler.HandleSelectedColor(_colors[elementNumber]);
    }
}