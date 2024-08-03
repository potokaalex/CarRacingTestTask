using Cysharp.Threading.Tasks;

namespace Client.Code.Services.StateMachine.State
{
    public interface IStateAsync : IStateBase
    {
        UniTask Enter();
        UniTask Exit();
    }
}