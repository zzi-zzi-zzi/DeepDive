/*
DeepDungeon is licensed under a
Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License.

You should have received a copy of the license along with this
work. If not, see <http://creativecommons.org/licenses/by-nc-sa/4.0/>.

Orginal work done by zzi, contibutions by Omninewb, Freiheit, and mastahg
                                                                                 */
using System;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using Deep.Memory.Attributes;
using ff14bot;
using ff14bot.Behavior;
using ff14bot.Enums;
using ff14bot.Managers;

namespace Deep.Memory
{

#pragma warning disable CS0649
    internal static class Offsets
    {
        [Offset("Search 0F B6 81 ? ? ? ? 4C 8D AE ? ? ? ? Add 3 Read32")]
        [OffsetCN("Search 0F B6 81 ? ? ? ? 49 8D 95 ? ? ? ? Add 3 Read32")]
        internal static int DDMapGroup;

        [Offset("Search 4C 8D AE ? ? ? ? 48 69 C8 ? ? ? ?   Add 3 Read32")]
        [OffsetCN("Search 49 8D 95 ? ? ? ? 48 69 C8 ? ? ? ?  Add 3 Read32")]
        internal static int Map5xStart;

        [Offset("Search 48 69 C8 ? ? ? ? 4C 03 E9 45 33 C9 Add 3 Read32")]
        [OffsetCN("Search 48 69 C8 ? ? ? ? 48 03 D1 45 Add 3 Read32")]
        internal static int Map5xSize;

        [Offset("Search 41 0F B7 85 ? ? ? ? 2B C8  Add 4 Read32")]
        [OffsetCN("Search 0F B7 82 ? ? ? ? 2B C8 48 8D 0C 89 Add 3 Read32")]
        internal static int WallStartingPoint;

        [Offset("Search 48 81 C3 ? ? ? ? 48 8D 3D ? ? ? ?  Add 3 Read32")]
        [OffsetCN("Search 49 8D BE ? ? ? ? 0F 1F 44 00 ? 8B 17 Add 3 Read32")]
        internal static int Starting;

        [Offset("Search F6 84 30 ? ? ? ? ? 74 0F  Add 3 Read32")]
        [OffsetCN("Search 42 0F B6 8C 28 ? ? ? ? 84 0E Add 5 Read32")]
        internal static int WallGroupEnabled;
    }
#pragma warning restore CS0649
}
