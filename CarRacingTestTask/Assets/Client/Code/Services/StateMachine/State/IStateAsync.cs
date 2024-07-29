using Cysharp.Threading.Tasks;

namespace Client.Code.Services.StateMachine.State
{
    public interface IStateAsync
    {
        UniTask Enter();
        UniTask Exit();
    }
}