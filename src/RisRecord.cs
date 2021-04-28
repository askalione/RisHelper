using RisHelper.Internal;
using RisHelper.Internal.FieldResolvers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RisHelper
{
    public class RisRecord
    {
        /// <summary>
        /// Type of reference
        /// </summary>
        [RisField(tag: "TY", resolverType: typeof(RisRecordTypeFieldResolver))]
        public RisRecordType Type { get; set; }
        /// <summary>
        /// Authors
        /// </summary>
        //public IEnumerable<RisRecordAuthor> Authors { get; set; }
        /// <summary>
        /// Abstract
        /// </summary>
        [RisField(tag: "AB")]
        public string Abstract { get; set; }
        /// <summary>
        /// Author Address
        /// </summary>
        [RisField(tag: "AD")]
        public string AuthorAddress { get; set; }
        /// <summary>
        /// Accession Number
        /// </summary>
        [RisField(tag: "AN")]
        public string AccessionNumber { get; set; }
        /// <summary>
        /// Location in Archives
        /// </summary>
        [RisField(tag: "AV")]
        public string LocationInArchives { get; set; }
        /// <summary>
        /// Book title. This field maps to T2 for all reference types except for Whole Book and Unpublished Work references
        /// </summary>
        [RisField(tag: "BT")]
        public string BookTitle { get; set; }


        public RisRecord()
        {
            //Authors = new List<RisRecordAuthor>();
        }
    }
}
