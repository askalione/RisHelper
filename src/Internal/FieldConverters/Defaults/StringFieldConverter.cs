namespace RisHelper.Internal.FieldConverters.Defaults
{
    internal class StringFieldConverter : FieldConverter<string>
    {
        protected override string Read(string tag, string srcValue, string destValue)
            => srcValue;

        protected override Field[] Write(string tag, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return [];
            }

            return [new Field(tag, value)];
        }
    }
}
