namespace RisHelper.Internal.FieldConverters
{
    internal abstract class FieldConverter<T> : IFieldConverter
    {
        public object Read(string tag, string srcValue, object destValue)
            => Read(tag, srcValue, (T)destValue);

        protected abstract T Read(string tag, string srcValue, T destValue);

        public string[] Write(string tag, object value)
            => Write(tag, (T)value);

        protected abstract string[] Write(string tag, T value);
    }
}
