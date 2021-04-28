namespace RisHelper.Internal.FieldResolvers
{
    internal class RisDefaultFieldResolver : RisFieldResolver<string>
    {
        protected override string Resolve(string tag, string srcValue, string destValue)
            => srcValue;
    }
}
