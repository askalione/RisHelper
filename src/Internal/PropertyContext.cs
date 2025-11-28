using System;
using System.Reflection;

namespace RisHelper.Internal
{
    internal class PropertyContext
    {
        public PropertyInfo Property { get; }
        public string Tag { get; }
        public IFieldConverter Converter { get; }

        public PropertyContext(PropertyInfo property,
            string tag,
            IFieldConverter converter)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException(nameof(tag));
            }
            if (converter == null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            Property = property;
            Tag = tag;
            Converter = converter;
        }
    }
}
