using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.StateMachine.State
{
    public interface IStateAsync : IStateBase
    {
        UniTask Enter();
    }
}