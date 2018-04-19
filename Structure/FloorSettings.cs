using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Deep.Properties;
using Newtonsoft.Json;

namespace Deep.Structure
{
    internal class FloorSetting : INotifyPropertyChanged
    {
        /// <summary>
        /// represents the highest level we before we reach the aether value.
        /// </summary>
        [JsonProperty("_levelMax")]
        public int LevelMax { get; set; }

        [JsonIgnore]
        public string Display => string.Format(Resources.UI_FloorSettingRow, LevelMax - 9, LevelMax, "");

        public override string ToString()
        {
            return string.Format(Resources.UI_FloorSettingRow, LevelMax - 9, LevelMax, "");
        }

        public override bool Equals(object obj)
        {
            return (obj as FloorSetting)?.LevelMax == LevelMax;
        }

        public override int GetHashCode()
        {
            return LevelMax.GetHashCode();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}