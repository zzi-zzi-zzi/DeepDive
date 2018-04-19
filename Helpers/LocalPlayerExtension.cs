using ff14bot.Managers;
using ff14bot.Objects;

namespace Deep.Helpers
{
    internal static class LocalPlayerExtension
    {
        /// <summary>
        /// are we really in combat?
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        internal static bool InRealCombat(this LocalPlayer player)
        {
            return player.InCombat || GameObjectManager.NumberOfAttackers > 0;
        }
    }
}