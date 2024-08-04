﻿using System.Collections.Generic;
using Client.Code.Services.Asset;
using Client.Code.Services.InputService;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Code.Data.Static.Configs.Project
{
    [CreateAssetMenu(menuName = "Configs/Project", fileName = "ProjectConfig", order = 0)]
    public class ProjectConfig : SerializedScriptableObject, IAsset
    {
        public Dictionary<SceneName, string> SceneNames;
        public InputObject InputPrefab;
        public ShopConfig Shop;
        public AudioConfig Audio;
    }
}