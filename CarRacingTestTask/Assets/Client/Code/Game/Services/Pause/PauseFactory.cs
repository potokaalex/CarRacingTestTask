using Client.Code.Game.Services.Checker;
using Zenject;

namespace Client.Code.Game.Services.Pause
{
    public class PauseFactory
    {
        private readonly IInstantiator _instantiation;
        private PauseChecker _checker;

        public PauseFactory(IInstantiator instantiation) => _instantiation = instantiation;
        
        public void Create()
        {
            _checker = _instantiation.Instantiate<PauseChecker>();
            _checker.Initialize();
        }

        public void Destroy() => _checker.Dispose();
    }
}