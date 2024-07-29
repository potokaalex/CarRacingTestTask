using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States
{
    public class GameplayState : IStateAsync
    {
        public UniTask Enter() => UniTask.CompletedTask;

        public UniTask Exit() => UniTask.CompletedTask;
    }
}