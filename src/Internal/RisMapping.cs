using System;
using System.Reflection;

namespace RisHelper.Internal
{
    internal class RisMapping
    {
        public PropertyInfo Property { get; }
        public IRisFieldResolver Resolver { get; }

        public RisMapping(PropertyInfo property, IRisFieldResolver resolver)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            if (resolver == null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }

            Property = property;
            Resolver = resolver;
        }
    }
}
