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