namespace RisHelper.Internal
{
    internal interface IRisFieldResolver
    {
        object Resolve(string tag, string srcValue, object destValue);
    }
}
