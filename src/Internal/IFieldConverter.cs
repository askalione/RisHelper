namespace RisHelper.Internal
{
    internal interface IFieldConverter
    {
        object Read(string tag, string srcValue, object destValue);
        // TODO: Write
    }
}
