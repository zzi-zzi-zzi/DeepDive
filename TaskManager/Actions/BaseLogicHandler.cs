using Buddy.Coroutines;
using Deep.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deep.TaskManager.Actions
{
    class BaseLogicHandler : ITask
    {
        public string Name => "BaseLogicHandler";

        public async Task<bool> Run()
        {
            Logger.Warn("We have reached the Base Logic Handler. This means the bot didn't know what to do.");
            await Coroutine.Sleep(100);
            return true;
        }

        public void Tick()
        {
            
        }
    }
}
