namespace RisHelper.Internal
{
    internal class Field
    {
        public string Tag { get; }
        public string Value { get; }

        public Field(string tag, string value)
        {
            Tag = tag;
            Value = value;
        }

        public override string ToString()
            => $"{Tag}{Constants.FieldValueSeparator}{Value}";
    }
}
