namespace RisHelper.Internal.FieldConverters.Defaults
{
    internal class StringFieldConverter : FieldConverter<string>
    {
        protected override string Read(string tag, string srcValue, string destValue)
            => srcValue;
    }
}
