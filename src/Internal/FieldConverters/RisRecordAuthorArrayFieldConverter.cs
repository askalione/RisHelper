using System.Collections.Generic;
using System.Linq;

namespace RisHelper.Internal.FieldConverters
{
    internal class RisRecordAuthorArrayFieldConverter : FieldConverter<RisRecordAuthor[]>
    {
        protected override RisRecordAuthor[] Read(string tag, string srcValue, RisRecordAuthor[] destValue)
        {
            List<RisRecordAuthor> value = destValue?.ToList() ?? [];

            RisRecordAuthorType? authorType = null;

            switch (tag)
            {
                case "A1":
                    authorType = RisRecordAuthorType.Primary;
                    break;
                case "A2":
                    authorType = RisRecordAuthorType.Secondary;
                    break;
                case "A3":
                    authorType = RisRecordAuthorType.Tertiary;
                    break;
                case "A4":
                    authorType = RisRecordAuthorType.Subsidiary;
                    break;
            }

            var author = new RisRecordAuthor
            {
                Value = srcValue,
                Type = authorType
            };

            value.Add(author);

            return value.ToArray();
        }

        protected override Field[] Write(string tag, RisRecordAuthor[] value)
        {
            List<RisRecordAuthor> destValues = value
                .Where(x => string.IsNullOrWhiteSpace(x.Value) == false)
                .ToList();

            if (destValues == null)
            {
                return [];
            }

            List<Field> result = [];

            foreach (RisRecordAuthor destValue in destValues)
            {
                string destTag = tag;

                switch (destValue.Type)
                {
                    case RisRecordAuthorType.Primary:
                        destTag = "A1";
                        break;
                    case RisRecordAuthorType.Secondary:
                        destTag = "A2";
                        break;
                    case RisRecordAuthorType.Tertiary:
                        destTag = "A3";
                        break;
                    case RisRecordAuthorType.Subsidiary:
                        destTag = "A4";
                        break;
                }

                result.Add(new Field(destTag, destValue.Value));
            }

            return result.ToArray();
        }
    }
}
