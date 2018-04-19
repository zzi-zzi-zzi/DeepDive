using Buddy.Coroutines;
using ff14bot;
using ff14bot.Behavior;
using ff14bot.Managers;
using ff14bot.RemoteAgents;
using ff14bot.RemoteWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deep.TaskManager.Actions
{
    class LoadingHandler : ITask
    {
        public string Name => "LoadingHandler";

        public async Task<bool> Run()
        {
            if(CommonBehaviors.IsLoading)
            {
                await Coroutine.Wait(-1, () => !CommonBehaviors.IsLoading);
                return true;
            }
            if(QuestLogManager.InCutscene)
            {
                TreeRoot.StatusText = "InCutscene";
                if (AgentCutScene.Instance != null)
                {
                    AgentCutScene.Instance.PromptSkip();
                    await Coroutine.Wait(250, () => SelectString.IsOpen);
                    if (SelectString.IsOpen)
                        SelectString.ClickSlot(0);
                    return true;
                }
            }
            if(Talk.DialogOpen)
            {
                Talk.Next();
                return true;
            }
            return false;
        }

        public void Tick()
        {
            
        }
    }
}
