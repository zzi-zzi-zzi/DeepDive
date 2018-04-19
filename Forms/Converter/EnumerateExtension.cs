using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using Deep.Properties;

namespace Deep.Forms.Converter
{
    [MarkupExtensionReturnType(typeof(IEnumerable<object>))]
    public sealed class EnumerateExtension : MarkupExtension
    {
        #region Fields

        private Type type;
        private IValueConverter converter;
        private CultureInfo converterCulture;
        private object converterParameter;

        #endregion

        #region Constructors

        public EnumerateExtension()
        {
        }

        public EnumerateExtension(Type type)
        {
            if (type == null)
            { throw new ArgumentNullException("type"); }

            this.Type = type;
        }

        #endregion

        #region MarkupExtension Members

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (type == null)
            { throw new InvalidOperationException(Resources.EnumTypeNotSet); }

            Type actualType = Nullable.GetUnderlyingType(type) ?? type;
            TypeConverter typeConverter;
            ICollection standardValues;

            if ((typeConverter = TypeDescriptor.GetConverter(actualType)) == null ||
                (standardValues = typeConverter.GetStandardValues(serviceProvider as ITypeDescriptorContext)) == null)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.TypeHasNoStandardValues,
                        type
                    ),
                    "value"
                );
            }

            object[] items = (type == actualType)
                ? new object[standardValues.Count]
                : new object[standardValues.Count + 1];
            int index = 0;

            if (converter == null)
            {
                foreach (object standardValue in standardValues)
                { items[index++] = standardValue; }
            }
            else
            {
                CultureInfo culture = converterCulture ?? GetCulture(serviceProvider);

                foreach (object standardValue in standardValues)
                { items[index++] = converter.Convert(standardValue, typeof(object), converterParameter, culture); }

                if (type != actualType)
                { items[index] = converter.Convert(null, typeof(object), converterParameter, culture); }
            }

            return items;
        }

        #endregion

        #region Properties

        [ConstructorArgument("type")]
        public Type Type
        {
            get { return type; }
            set { type = value; }
        }

        public IValueConverter Converter
        {
            get { return converter; }
            set { converter = value; }
        }

        public CultureInfo ConverterCulture
        {
            get { return converterCulture; }
            set { converterCulture = value; }
        }

        public object ConverterParameter
        {
            get { return converterParameter; }
            set { converterParameter = value; }
        }

        #endregion

        #region Private Methods

        private static CultureInfo GetCulture(IServiceProvider serviceProvider)
        {
            if (serviceProvider != null)
            {
                IProvideValueTarget provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;

                if (provideValueTarget != null)
                {
                    DependencyObject targetObject = provideValueTarget.TargetObject as DependencyObject;
                    XmlLanguage language;

                    if ((targetObject = provideValueTarget.TargetObject as DependencyObject) != null &&
                        (language = (XmlLanguage)targetObject.GetValue(FrameworkElement.LanguageProperty)) != null)
                    { return language.GetSpecificCulture(); }
                }
            }

            return null;
        }

        #endregion
    }
}