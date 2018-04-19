using Deep.Logging;
using Deep.Providers;
using Deep.Structure;
using System;
using System.Windows.Forms;

namespace Deep.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            settings.SelectedObject = Settings.Instance;
            Settings.Instance.EnsureFloorSettings();
            Levels.DataSource = Settings.Instance.FloorSettings;
            Levels.SelectedItem = Settings.Instance.SelectedLevel;
            Levels.SelectedIndexChanged += changelevel;
            solostop.Checked = !Settings.Instance.SoloStop;

            solostop.CheckedChanged += solostop_CheckStateChanged;

        }

        private void changelevel(object sender, EventArgs e)
        {
            Logger.Verbose($"Changing the selected floor to run");
            Settings.Instance.SelectedLevel = (FloorSetting)Levels.SelectedItem;
        }

        private void Levels_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Instance.SelectedLevel = (FloorSetting)Levels.SelectedItem;
        }

        private void solostop_CheckStateChanged(object sender, EventArgs e)
        {
            Logger.Verbose($"Changing stop state");
            Settings.Instance.SoloStop = !Settings.Instance.SoloStop;
        }

    }
}
