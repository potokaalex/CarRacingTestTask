using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States.Gameplay
{
    public class GameplayGameOverState : IStateAsync
    {
        public UniTask Enter()
        {
            //создаю ui конца игры.
            UnityEngine.Debug.Log("GameEnd!");
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}