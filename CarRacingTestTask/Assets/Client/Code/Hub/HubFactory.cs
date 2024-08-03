using System.Collections.Generic;
using Client.Code.Data;
using Client.Code.Data.Hub;
using Client.Code.Infrastructure.Installers;
using Client.Code.Services.Asset.Receiver;
using Client.Code.UI.Windows;
using Client.Code.UI.Windows.SelectLevel;
using UnityEngine;
using Zenject;

namespace Client.Code.Hub
{
    public class HubFactory : IAssetReceiver<HubConfig>, ISelectLevelWindowFactory
    {
        private readonly List<WindowBase> _windows = new();
        private readonly HubSceneData _sceneData;
        private readonly IInstantiator _instantiator;
        private HubConfig _config;

        public HubFactory(HubSceneData sceneData, IInstantiator instantiator)
        {
            _sceneData = sceneData;
            _instantiator = instantiator;
        }

        public void Receive(HubConfig asset) => _config = asset;

        void ISelectLevelWindowFactory.Create()
        {
            if (TryGetWindow(WindowType.SelectLevel, out var window))
                window.Open();
            else
                CreateWindow(_config.SelectLevelWindowPrefab, _sceneData.Canvas.SelectLevelWindowSpawnPoint);
        }

        private void CreateWindow(WindowBase windowPrefab, Transform root)
        {
            var newWindow = _instantiator.InstantiatePrefabForComponent<SelectLevelWindow>(windowPrefab, root);
            newWindow.Open();
            _windows.Add(newWindow);
        }

        void ISelectLevelWindowFactory.Destroy()
        {
            if (TryGetWindow(WindowType.SelectLevel, out var window))
                window.Close();
        }

        private bool TryGetWindow(WindowType type, out WindowBase resultWindow)
        {
            foreach (var window in _windows)
            {
                if (window.GetBaseType() == type)
                {
                    resultWindow = window;
                    return true;
                }
            }

            resultWindow = null;
            return false;
        }
    }
}