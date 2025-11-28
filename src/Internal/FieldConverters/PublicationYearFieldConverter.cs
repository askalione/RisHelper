using System;

namespace RisHelper.Internal.FieldConverters
{
    internal class PublicationYearFieldConverter : FieldConverter<int?>
    {
        protected override int? Read(string tag, string srcValue, int? destValue)
        {
            if (string.IsNullOrWhiteSpace(srcValue) == false)
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

        protected override Field[] Write(string tag, int? value)
        {
            if (value == null)
            {
                return [];
            }

            return [new Field(tag, value.ToString())];
        }
    }
}
