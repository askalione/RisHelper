using System.Collections.Generic;
using System.Linq;

namespace RisHelper.Internal.FieldConverters
{
    internal class RisRecordTitleListFieldConverter : FieldConverter<IEnumerable<RisRecordTitle>>
    {
        protected override IEnumerable<RisRecordTitle> Read(string tag, string srcValue, IEnumerable<RisRecordTitle> destValue)
        {
            var value = destValue?.ToList() ?? new List<RisRecordTitle>();

            RisRecordTitleType? type = null;

            switch (tag)
            {
                case "T1":
                    type = RisRecordTitleType.Primary;
                    break;
                case "T2":
                    type = RisRecordTitleType.Secondary;
                    break;
                case "T3":
                    type = RisRecordTitleType.Tertiary;
                    break;
            }

            var title = new RisRecordTitle
            {
                Value = srcValue,
                Type = type
            };

            value.Add(title);

            return value;
        }
    }
}
