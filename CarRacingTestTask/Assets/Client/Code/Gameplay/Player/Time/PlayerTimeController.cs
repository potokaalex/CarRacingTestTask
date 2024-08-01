using System.Diagnostics;
using UnityEngine;

namespace Client.Code.Gameplay.Player.Time
{
    public class PlayerTimeController
    {
        private readonly Stopwatch _stopwatch = new();
        private PlayerTimeView _view;
        private float _currentTimeMs;
        private float _maxTimeMs;

        public float CurrentTimeMs => _currentTimeMs;

        public void Initialize(PlayerTimeView view, float maxTimeMs)
        {
            _view = view;
            _maxTimeMs = maxTimeMs;
            _stopwatch.Start();
        }

        public void Dispose() => _stopwatch.Stop();

        public void OnUpdate()
        {
            _currentTimeMs = Mathf.Clamp(_stopwatch.ElapsedMilliseconds, 0, _maxTimeMs);
            _view.SetTime(_currentTimeMs);
        }
    }
}