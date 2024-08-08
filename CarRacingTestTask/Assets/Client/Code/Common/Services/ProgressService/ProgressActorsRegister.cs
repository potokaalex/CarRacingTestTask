using System.Collections.Generic;
using Client.Code.Common.Services.ProgressService.Loader;
using Client.Code.Common.Services.ProgressService.Saver;
using Zenject;

namespace Client.Code.Common.Services.ProgressService
{
    public class ProgressActorsRegister<T> : IInitializable, ILateDisposable where T : IProgress
    {
        private readonly IProgressSaver<T> _saver;
        private readonly IProgressLoader<T> _loader;
        private readonly List<IProgressReader<T>> _readers;
        private readonly List<IProgressWriter<T>> _writers;

        public ProgressActorsRegister(IProgressSaver<T> saver, IProgressLoader<T> loader, List<IProgressReader<T>> readers,
            List<IProgressWriter<T>> writers)
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

        public void LateDispose()
        {
            foreach (var reader in _readers)
                _loader.UnRegister(reader);

            foreach (var writer in _writers)
                _saver.UnRegister(writer);
        }
    }
}