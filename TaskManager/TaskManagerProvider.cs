using Deep.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deep.TaskManager
{

    interface ITask
    {
        string Name { get; }
        void Tick();
        Task<bool> Run();
    }
        


    class TaskManagerProvider : List<ITask>
    {
        public TaskManagerProvider() { }

        public void Tick()
        {
            foreach(var x in this)
            {
                try
                {
                    x.Tick();
                }
                catch (Exception ex)
                {
                    Logger.Warn($"[TaskManager][Tick] {x.Name} threw an Exception {ex}");
                }
            }
        }

        public async Task<bool> Run()
        {
            foreach(var x in this)
            {
                try
                {
                    if (await x.Run())
                        return true;
                }
                catch (Exception ex)
                {
                    Logger.Warn($"[TaskManager][Run] {x.Name} threw an Exception {ex}");
                    return false;
                }
            }
            return false;
        }
    }
}
