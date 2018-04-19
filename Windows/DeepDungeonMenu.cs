using System;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot.Managers;
using Deep.Helpers;
using Deep.Logging;


namespace Deep.Windows
{
    internal class DeepDungeonMenu
    {
        internal static bool IsOpen => RaptureAtkUnitManager.GetWindowByName(WindowNames.DDmenu) != null;

        internal static async Task OpenSaveMenu()
        {
            var menu = RaptureAtkUnitManager.GetWindowByName(WindowNames.DDmenu);
            if (menu == null) return;
            try
            {
                menu.SendAction(1, 3, 0);
                await Coroutine.Wait(3000,() => DeepDungeonSaveData.IsOpen);
            }
            catch (Exception ex)
            {
                Logger.Verbose("{0}", ex);
            }
            
        }

        internal static async Task OpenResetMenu()
        {
            var wind = RaptureAtkUnitManager.GetWindowByName(WindowNames.DDmenu);
            if(wind == null)
                throw new Exception("Open Reset Menu Failed. POTD Menu is not open. (The bot will attempt to correct this issue)");
            wind.SendAction(1, 3, 1);
            await Coroutine.Wait(3000, () => DeepDungeonSaveData.IsOpen);
        }

    }
}