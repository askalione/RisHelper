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

        protected override string[] Write(string tag, IEnumerable<RisRecordTitle> value)
        {
            var destValues = value
                 .Where(x => string.IsNullOrEmpty(x.Value) == false)
                 .ToList();

            if (destValues == null)
            {
                return null;
            }

            var result = new List<string>();

            foreach (var destValue in destValues)
            {
                var destTag = tag;

                switch (destValue.Type)
                {
                    case RisRecordTitleType.Primary:
                        destTag = "T1";
                        break;
                    case RisRecordTitleType.Secondary:
                        destTag = "T2";
                        break;
                    case RisRecordTitleType.Tertiary:
                        destTag = "T3";
                        break;
                }

                result.Add(destTag + Constants.FieldValueSeparator + destValue);
            }

            return result.ToArray();
        }
    }
}
