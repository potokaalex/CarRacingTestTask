using UnityEngine;
using UnityEngine.Pool;

namespace Client.Code.Common.Services.Extensions
{
    public static class MeshRendererExtensions
    {
        public static void ChangeSharedMaterials(this MeshRenderer meshRenderer, Material material, int index)
        {
            var list = ListPool<Material>.Get();
            meshRenderer.GetSharedMaterials(list);
            list[index] = material;
            meshRenderer.SetSharedMaterials(list);
            ListPool<Material>.Release(list);
        }
    }
}