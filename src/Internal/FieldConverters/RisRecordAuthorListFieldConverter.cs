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
    }
}
