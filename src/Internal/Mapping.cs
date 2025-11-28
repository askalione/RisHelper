using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace RisHelper.Internal
{
    internal static class Mapping
    {
        private static readonly ConcurrentDictionary<Type, IFieldConverter> _converters = new ConcurrentDictionary<Type, IFieldConverter>();
        private static readonly ConcurrentDictionary<string, PropertyContext> _propertiesContexts = new ConcurrentDictionary<string, PropertyContext>();
        private static readonly ConcurrentDictionary<string, PropertyContext> _tagMappings = new ConcurrentDictionary<string, PropertyContext>();

        static Mapping()
        {
            var type = typeof(RisRecord);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    if (attribute is FieldAttribute fieldAttribute)
                    {
                        var tags = fieldAttribute.Tag.Split(',').Select(x => x.Trim());
                        foreach (var tag in tags)
                        {
                            var converter = _converters.GetOrAdd(fieldAttribute.ConverterType,
                                (t) => (IFieldConverter)Activator.CreateInstance(fieldAttribute.ConverterType));

                            var propertyContext = new PropertyContext(property, tag, converter);
                            _propertiesContexts.GetOrAdd(property.Name, (k) => propertyContext);
                            _tagMappings.AddOrUpdate(tag, (k) => propertyContext, (k, s) => propertyContext);

                        }
                    }
                }
            }
        }

        public static bool TryGetPropertyContext(PropertyInfo property, out PropertyContext propertyMapping)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return _propertiesContexts.TryGetValue(property.Name, out propertyMapping);
        }

        public static bool TryGetPropertyContext(string tag, out PropertyContext propertyMapping)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException(nameof(tag));
            }

            return _tagMappings.TryGetValue(tag, out propertyMapping);
        }
    }
}
