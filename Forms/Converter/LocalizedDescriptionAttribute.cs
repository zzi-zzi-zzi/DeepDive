/*
DeepDungeon is licensed under a
Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License.

You should have received a copy of the license along with this
work. If not, see <http://creativecommons.org/licenses/by-nc-sa/4.0/>.

Orginal work done by zzi, contibutions by Omninewb, Freiheit, and mastahg
                                                                                 */
using System.ComponentModel;
using Deep.Properties;

namespace Deep.Forms.Converter
{
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        #region Fields

        private string resourceName;

        #endregion

        #region Constructors

        public LocalizedDescriptionAttribute(string resourceName)
        {
            this.resourceName = resourceName;
        }

        #endregion

        #region DescriptionAttribute Members

        public override string Description
        {
            get { return Resources.ResourceManager.GetString(resourceName); }
        }

        #endregion

        #region Properties

        public string ResourceName
        {
            get { return resourceName; }
        }

        #endregion
    }
}