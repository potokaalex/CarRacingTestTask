using Client.Code.Common.Services.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Code.CompositionRoot.Utilities
{
    public class BootstrapLoader : MonoBehaviour
    {
        [SerializeField] private string _bootstrapSceneName;

        private void Awake()
        {
            if (!PlatformsConstants.IsEditor)
                return;

            if (SceneManager.GetActiveScene().name != _bootstrapSceneName)
                SceneManager.LoadScene(_bootstrapSceneName);
        }
    }
}