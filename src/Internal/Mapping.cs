using System;
using System.Reflection;

namespace RisHelper.Internal
{
    internal class Mapping
    {
        public PropertyInfo Property { get; }
        public IFieldConverter Converter { get; }

        public Mapping(PropertyInfo property, IFieldConverter converter)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            if (converter == null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            Property = property;
            Converter = converter;
        }
    }
}
