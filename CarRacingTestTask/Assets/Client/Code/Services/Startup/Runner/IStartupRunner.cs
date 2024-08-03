using UnityEngine.SceneManagement;

namespace Client.Code.Services.Startup.Runner
{
    public interface IStartupRunner
    {
        void Run(Scene scene);
    }
}