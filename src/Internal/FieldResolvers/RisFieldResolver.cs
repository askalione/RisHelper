namespace RisHelper.Internal.FieldResolvers
{
    internal abstract class RisFieldResolver<T> : IRisFieldResolver
    {
        public object Resolve(string tag, string srcValue, object destValue)
            => Resolve(tag, srcValue, (T)destValue);

        protected abstract T Resolve(string tag, string srcValue, T destValue);
    }
}
