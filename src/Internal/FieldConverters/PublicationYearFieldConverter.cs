using System;

namespace RisHelper.Internal.FieldConverters
{
    internal class PublicationYearFieldConverter : FieldConverter<int?>
    {
        protected override int? Read(string tag, string srcValue, int? destValue)
        {
            if (string.IsNullOrEmpty(srcValue) == false)
            {
                if (int.TryParse(srcValue, out int year))
                {
                    return year;
                }

                if (DateTime.TryParse(srcValue, out DateTime date))
                {
                    return date.Year;
                }
            }

            return null;
        }

        protected override string[] Write(string tag, int? value)
        {
            if (value == null)
            {
                return null;
            }

            return new[] { tag + Constants.FieldValueSeparator + value };
        }
    }
}
