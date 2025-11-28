using System.Collections.Generic;
using System.Linq;

namespace RisHelper.Internal.FieldConverters.Defaults
{
    internal class StringArrayFieldConverter : FieldConverter<string[]>
    {
        protected override string[] Read(string tag, string srcValue, string[] destValue)
        {
            List<string> value = destValue?.ToList() ?? [];
            if (value.Contains(srcValue) == false)
            {
                value.Add(srcValue);
            }

            return value.ToArray();
        }

        protected override Field[] Write(string tag, string[] value)
        {
            List<string> destValues = value
                .Where(x => string.IsNullOrEmpty(x) == false)
                .ToList();

            if (destValues.Any() == false)
            {
                return [];
            }

            return destValues
                .Select(x => new Field(tag, x))
                .ToArray();
        }
    }
}
