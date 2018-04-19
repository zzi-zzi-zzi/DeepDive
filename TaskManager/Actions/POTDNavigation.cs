using Clio.Utilities;
using Deep.Helpers;
using Deep.Memory;  
using Deep.Providers;
using ff14bot;
using ff14bot.Behavior;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Navigation;
using ff14bot.Pathing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deep.TaskManager.Actions
{
    class POTDNavigation : ITask
    {
        public string Name => "PotdNavigator";

        private int PortalPercent => (int)Math.Ceiling((DeepDungeonManager.PortalStatus / 11) * 100f);

        private Poi Target => Poi.Current;

        public async Task<bool> Run()
        {
            if (!Constants.InDeepDungeon)
                return false;

            
            if (Target == null)
                return false;



            if(Navigator.InPosition(Core.Me.Location, Target.Location, 3f) && Target.Type == (PoiType)PoiTypes.ExplorePOI)
            {
                Poi.Clear("We have reached our destination");
                return true;
            }
            var status = string.Format("Current Level {0}. Level Status: {1}% \"Done\": {2}", DeepDungeonManager.Level,
                            PortalPercent, DDTargetingProvider.Instance.LevelComplete);
            TreeRoot.StatusText = status;
            
            if (ActionManager.IsSprintReady && Target.Location.Distance2D(Core.Me.Location) > 5 && MovementManager.IsMoving)
            {
                ActionManager.Sprint();
                return true;
            }

            var res = await CommonTasks.MoveAndStop(new MoveToParameters(Target.Location, "Moving toward POTD Objective"), 1.5f);

            //if (Target.Unit != null)
            //{
            //    Logger.Verbose($"[PotdNavigator] Move Results: {res} Moving To: \"{Target.Unit.Name}\" LOS: {Target.Unit.InLineOfSight()}");
            //}
            //else
            //{
            //    Logger.Verbose($"[PotdNavigator] Move Results: {res} Moving To: \"{Target.Name}\" ");
            //}
            

            return res;

        }

        private int level = 0;

        private List<Vector3> SafeSpots;


        public void Tick()
        {
            if (!Constants.InDeepDungeon || CommonBehaviors.IsLoading || QuestLogManager.InCutscene)
                return;

            if(level != DeepDungeonManager.Level)
            {
                level = DeepDungeonManager.Level;
                SafeSpots = new List<Vector3>();
                SafeSpots.AddRange(GameObjectManager.GameObjects.Where(i => i.Location != Vector3.Zero).Select(i => i.Location));
            }

            if (!SafeSpots.Any(i => i.Distance2D(Core.Me.Location) < 5))
                SafeSpots.Add(Core.Me.Location);

            

            
            if(Poi.Current == null || Poi.Current.Type == PoiType.None)
                Poi.Current = new Poi(SafeSpots.OrderByDescending(i => i.Distance2D(Core.Me.Location)).First(), (PoiType)PoiTypes.ExplorePOI);
            
        }
    }
}
