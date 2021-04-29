using System.Collections.Generic;
using System.Linq;

namespace RisHelper.Internal.FieldConverters.Defaults
{
    internal class StringListFieldConverter : FieldConverter<IEnumerable<string>>
    {
        protected override IEnumerable<string> Read(string tag, string srcValue, IEnumerable<string> destValue)
        {
            var value = destValue?.ToList() ?? new List<string>();
            if (value.Contains(srcValue) == false)
            {
                value.Add(srcValue);
            }

            return value;
        }

        protected override string[] Write(string tag, IEnumerable<string> value)
        {
            var destValues = value
                .Where(x => string.IsNullOrEmpty(x) == false)
                .ToList();

            if (destValues.Count == 0)
            {
                return null;
            }

            return destValues.Select(x => tag + Constants.FieldValueSeparator + x).ToArray();
        }
    }
}
