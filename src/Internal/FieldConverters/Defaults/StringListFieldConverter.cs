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
    }
}
