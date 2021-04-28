using RisHelper.Internal.FieldResolvers;
using System;

namespace RisHelper.Internal
{
    internal class RisFieldAttribute : Attribute
    {
        public string Tag { get; }
        public Type ResolverType { get; }

        public RisFieldAttribute(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                throw new ArgumentNullException(nameof(tag));
            }

            Tag = tag;
            ResolverType = typeof(RisDefaultFieldResolver);
        }

        public RisFieldAttribute(string tag, Type resolverType) : this(tag)
        {
            if (resolverType == null)
            {
                throw new ArgumentNullException(nameof(resolverType));
            }
            // TODO: Validate resolverType by IRisFieldResolver

            ResolverType = resolverType;
        }
    }
}
