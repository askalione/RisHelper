namespace RisHelper.Internal.FieldConverters.Defaults
{
    internal class StringFieldConverter : FieldConverter<string>
    {
        protected override string Read(string tag, string srcValue, string destValue)
            => srcValue;

        protected override string[] Write(string tag, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return new[] { tag + Constants.FieldValueSeparator + value };
        }
    }
}
