using System;
using System.Diagnostics;
using Deep.Logging;

namespace Deep.Helpers
{
    [DebuggerStepThrough]
    internal class PerformanceLogger : IDisposable
    {
        private readonly string _blockName;
        private readonly Stopwatch _stopwatch;
        private bool _isDisposed;
        private readonly bool _forceLog;

        public PerformanceLogger(string blockName, bool forceLog = false)
        {
            _forceLog = forceLog;
            _blockName = blockName;
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_isDisposed) return;
            _isDisposed = true;
            _stopwatch.Stop();
            if (_stopwatch.Elapsed.TotalMilliseconds > 5 || _forceLog)
            {
                if (_stopwatch.Elapsed.TotalMilliseconds >= 500)
                {
                    Logger.Error("[Performance] Execution of \"{0}\" took {1:00.00000}ms.", _blockName,
                        _stopwatch.Elapsed.TotalMilliseconds);
                }
            }
            _stopwatch.Reset();
        }

        #endregion

        ~PerformanceLogger()
        {
            Dispose();
        }
    }
}