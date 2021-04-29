namespace RisHelper.Internal
{
    internal interface IFieldConverter
    {
        object Read(string tag, string srcValue, object destValue);
        string[] Write(string tag, object value);
    }
}
