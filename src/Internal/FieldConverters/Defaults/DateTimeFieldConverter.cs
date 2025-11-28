using System;

namespace RisHelper.Internal.FieldConverters.Defaults
{
    internal class DateTimeFieldConverter : FieldConverter<DateTime>
    {
        protected override DateTime Read(string tag, string srcValue, DateTime destValue)
            => DateTime.Parse(srcValue);

        protected override Field[] Write(string tag, DateTime value)
            => [new Field(tag, value.ToString("yyyy/MM/dd"))];
    }
}
