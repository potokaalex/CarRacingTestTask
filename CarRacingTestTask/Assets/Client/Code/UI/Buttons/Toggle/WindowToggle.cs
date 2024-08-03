﻿using Client.Code.UI.Windows;
using UnityEngine;
using Zenject;

namespace Client.Code.UI.Buttons.Toggle
{
    public class WindowToggle : ButtonBase
    {
        [SerializeField] private WindowType _type;
        private IWindowToggleHandler _handler;

        [Inject]
        public void Construct(IWindowToggleHandler handler) => _handler = handler;

        private protected override void OnClick() => _handler.Handle(_type);
    }
}