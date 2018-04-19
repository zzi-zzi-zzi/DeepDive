using System;
using ff14bot;

namespace Deep.Helpers
{
    internal class FrameCache<T>
    {
        private Func<T> _producer;
        private uint _lastFrame = uint.MaxValue;
        private T _cached;

        public FrameCache(Func<T> producer)
        {
            _producer = producer ?? throw new ArgumentNullException("producer");
        }

        public T Value
        {
            get
            {
                var frameCount = Core.Memory.Executor.FrameCount;
                if (_lastFrame != frameCount)
                {
                    _cached = _producer();
                    _lastFrame = frameCount;
                }
                return _cached;
            }
        }

        internal bool NeedsUpdating => Core.Memory.Executor.FrameCount != _lastFrame;

        public static implicit operator T(FrameCache<T> pfcv)
        {
            return pfcv.Value;
        }

    }
}