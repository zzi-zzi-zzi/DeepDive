using Deep.Helpers;
using Deep.Logging;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deep.TaskManager.Actions
{
    /// <summary>
    /// does an hp check for traps
    /// </summary>
    /// <returns></returns>
    class TrapHandler : ITask
    {
        private bool HasTrapAura => Core.Me.HasAnyAura(Auras.Pacification, Auras.Silence, Auras.Toad, Auras.Frog, Auras.Toad2);


        public string Name => "TrapHandler";

        public async Task<bool> Run()
        {
            if (!HasTrapAura) return false;
            if (CombatTargeting.Instance.FirstEntity == null) return false;

            if (Core.Me.InRealCombat())
            {
                return false;
            }
            TreeRoot.StatusText = "Waiting on Trap Auras";
            Logger.Info("Trap auras detected");

            if (Core.Me.HasAura(Auras.Silence) && Settings.Instance.UseEchoDrops)
            {
                if (await Tasks.Coroutines.Common.UseItemById(Items.EchoDrops))
                    return true;
            }
            Navigator.Clear();

            return true;
        }

        
        public void Tick()
        {
            
        }
    }
}
