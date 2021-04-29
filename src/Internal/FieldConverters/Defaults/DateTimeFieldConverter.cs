using System;

namespace RisHelper.Internal.FieldConverters.Defaults
{
    internal class DateTimeFieldConverter : FieldConverter<DateTime>
    {
        protected override DateTime Read(string tag, string srcValue, DateTime destValue)
            => DateTime.Parse(srcValue);

        protected override string[] Write(string tag, DateTime value)
            => new[] { tag + Constants.FieldValueSeparator + value.ToString("yyyy/MM/dd") };
    }
}
