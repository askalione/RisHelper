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
    }
}
