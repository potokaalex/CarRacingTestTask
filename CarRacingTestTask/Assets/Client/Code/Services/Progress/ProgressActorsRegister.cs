using System;
using System.Collections.Generic;
using Client.Code.Services.Progress.Loader;
using Client.Code.Services.Progress.Saver;
using Zenject;

namespace Client.Code.Services.Progress
{
    public class ProgressActorsRegister : IInitializable, ILateDisposable
    {
        private readonly IProgressSaver _saver;
        private readonly IProgressLoader _loader;
        private readonly List<IProgressReader> _readers;
        private readonly List<IProgressWriter> _writers;

        public ProgressActorsRegister(IProgressSaver saver, IProgressLoader loader, List<IProgressReader> readers, List<IProgressWriter> writers)
        {
            _saver = saver;
            _loader = loader;
            _readers = readers;
            _writers = writers;
        }

        public void Initialize()
        {
            foreach (var reader in _readers)
                _loader.Register(reader);

            foreach (var writer in _writers)
                _saver.Register(writer);
        }

        //when game exit, the save is invoked on Dispose, so actors cleared on LateDispose to save their data
        public void LateDispose()
        {
            foreach (var reader in _readers)
                _loader.UnRegister(reader);

            foreach (var writer in _writers)
                _saver.UnRegister(writer);
        }
    }
}