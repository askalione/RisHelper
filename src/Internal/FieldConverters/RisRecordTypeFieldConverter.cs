using System;

namespace RisHelper.Internal.FieldConverters
{
    internal class RisRecordTypeFieldConverter : FieldConverter<RisRecordType>
    {
        protected override RisRecordType Read(string tag, string srcValue, RisRecordType destValue)
            => (RisRecordType)Enum.Parse(typeof(RisRecordType), srcValue);
    }
}
