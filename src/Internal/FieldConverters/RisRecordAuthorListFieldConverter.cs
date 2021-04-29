using System.Collections.Generic;
using System.Linq;

namespace RisHelper.Internal.FieldConverters
{
    internal class RisRecordAuthorListFieldConverter : FieldConverter<IEnumerable<RisRecordAuthor>>
    {
        protected override IEnumerable<RisRecordAuthor> Read(string tag, string srcValue, IEnumerable<RisRecordAuthor> destValue)
        {
            var value = destValue?.ToList() ?? new List<RisRecordAuthor>();

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

            return value;
        }

        protected override string[] Write(string tag, IEnumerable<RisRecordAuthor> value)
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

                result.Add(destTag + Constants.FieldValueSeparator + destValue);
            }

            return result.ToArray();
        }
    }
}
