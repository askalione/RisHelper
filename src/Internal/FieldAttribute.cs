using RisHelper.Internal.FieldConverters.Defaults;
using System;

namespace RisHelper.Internal
{
    internal class FieldAttribute : Attribute
    {
        public string Tag { get; }
        public Type ConverterType { get; }

        public FieldAttribute(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException(nameof(tag));
            }

            Tag = tag;
            ConverterType = typeof(StringFieldConverter);
        }

        public FieldAttribute(string tag, Type converterType) : this(tag)
        {
            if (converterType == null)
            {
                throw new ArgumentNullException(nameof(converterType));
            }
            // TODO: Validate resolverType by IRisFieldResolver

            ConverterType = converterType;
        }
    }
}
