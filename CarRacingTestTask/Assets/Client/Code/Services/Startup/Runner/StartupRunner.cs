using System;
using System.Collections.Generic;
using Client.Code.Services.Startup.Delayed;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Code.Services.Startup.Runner
{
    public class StartupRunner : IStartupRunner
    {
        private readonly List<GameObject> _sceneRootObjects = new();

        public void Run(string sceneName)
        {
            var scene = SceneManager.GetSceneByName(sceneName);
            scene.GetRootGameObjects(_sceneRootObjects);

            foreach (var rootObject in _sceneRootObjects)
            {
                if (rootObject.TryGetComponent<DelayedStartupperMono>(out var startuper))
                {
                    startuper.Startup();
                    return;
                }
            }

            throw new Exception($"Cant find startupper on {scene.name} scene");
        }
    }
}