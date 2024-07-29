using System;
using Client.Code.Services.StateMachine;
using UnityEngine;
using Zenject;

namespace Client.Code.Services.Startup.Delayed
{
    public class DelayedStartupperMono : MonoBehaviour
    {
        private IStateMachine _stateMachine;
        private Type _stateType;

        [Inject]
        public void Construct(IStateMachine stateMachine, Type stateType)
        {
            _stateMachine = stateMachine;
            _stateType = stateType;
        }

        public void Startup() => _stateMachine.SwitchTo(_stateType);
    }
}