using System;

namespace RisHelper.Internal.FieldConverters.Defaults
{
    internal class DateTimeNullableFieldConverter : FieldConverter<DateTime?>
    {
        protected override DateTime? Read(string tag, string srcValue, DateTime? destValue)
        {
            if (string.IsNullOrEmpty(srcValue) == false)
            {
                if (DateTime.TryParse(srcValue, out DateTime date))
                {
                    return date;
                }
            }

            return null;
        }

        protected override string[] Write(string tag, DateTime? value)
        {
            if (value.HasValue == false)
            {
                return null;
            }

            return new[] { tag + Constants.FieldValueSeparator + value.Value.ToString("yyyy/MM/dd") };
        }
    }
}
