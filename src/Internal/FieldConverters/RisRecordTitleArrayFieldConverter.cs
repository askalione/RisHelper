using System.Collections.Generic;
using System.Linq;

namespace RisHelper.Internal.FieldConverters
{
    internal class RisRecordTitleArrayFieldConverter : FieldConverter<RisRecordTitle[]>
    {
        protected override RisRecordTitle[] Read(string tag, string srcValue, RisRecordTitle[] destValue)
        {
            List<RisRecordTitle> value = destValue?.ToList() ?? [];

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

            return value.ToArray();
        }

        protected override Field[] Write(string tag, RisRecordTitle[] value)
        {
            List<RisRecordTitle> destValues = value
                 .Where(x => string.IsNullOrEmpty(x.Value) == false)
                 .ToList();

            if (destValues == null)
            {
                return [];
            }

            List<Field> result = [];

            foreach (RisRecordTitle destValue in destValues)
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

                result.Add(new Field(destTag, destValue.Value));
            }

            return result.ToArray();
        }
    }
}
