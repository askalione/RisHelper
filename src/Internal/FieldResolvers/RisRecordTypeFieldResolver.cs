using System;

namespace RisHelper.Internal.FieldResolvers
{
    internal class RisRecordTypeFieldResolver : RisFieldResolver<RisRecordType>
    {
        protected override RisRecordType Resolve(string tag, string srcValue, RisRecordType destValue)
            => (RisRecordType)Enum.Parse(typeof(RisRecordType), srcValue);
    }
}
