using RisHelper.Internal;
using RisHelper.Internal.FieldConverters;
using RisHelper.Internal.FieldConverters.Defaults;
using System;
using System.Collections.Generic;

namespace RisHelper
{
    public class RisRecord
    {
        /// <summary>
        /// Type of reference
        /// </summary>
        [Field(tag: "TY", converterType: typeof(RisRecordTypeFieldConverter))]
        public RisRecordType Type { get; set; }
        /// <summary>
        /// Authors
        /// </summary>
        [Field(tag: "AU,A1,A2,A3,A4", converterType: typeof(RisRecordAuthorListFieldConverter))]
        public IEnumerable<RisRecordAuthor> Authors { get; set; }
        /// <summary>
        /// Abstract
        /// </summary>
        [Field(tag: "AB")]
        public string Abstract { get; set; }
        /// <summary>
        /// Author Address
        /// </summary>
        [Field(tag: "AD")]
        public string AuthorAddress { get; set; }
        /// <summary>
        /// Accession Number
        /// </summary>
        [Field(tag: "AN")]
        public string AccessionNumber { get; set; }
        /// <summary>
        /// Location in Archives
        /// </summary>
        [Field(tag: "AV")]
        public string LocationInArchives { get; set; }
        /// <summary>
        /// Book title. This field maps to T2 for all reference types except for Whole Book and Unpublished Work references
        /// </summary>
        [Field(tag: "BT")]
        public string BookTitle { get; set; }
        /// <summary>
        /// Custom 1
        /// </summary>
        [Field(tag: "C1")]
        public string Custom1 { get; set; }
        /// <summary>
        /// Custom 2
        /// </summary>
        [Field(tag: "C2")]
        public string Custom2 { get; set; }
        /// <summary>
        /// Custom 3
        /// </summary>
        [Field(tag: "C3")]
        public string Custom3 { get; set; }
        /// <summary>
        /// Custom 4
        /// </summary>
        [Field(tag: "C4")]
        public string Custom4 { get; set; }
        /// <summary>
        /// Custom 5
        /// </summary>
        [Field(tag: "C5")]
        public string Custom5 { get; set; }
        /// <summary>
        /// Custom 6
        /// </summary>
        [Field(tag: "C6")]
        public string Custom6 { get; set; }
        /// <summary>
        /// Custom 7
        /// </summary>
        [Field(tag: "C7")]
        public string Custom7 { get; set; }
        /// <summary>
        /// Custom 8
        /// </summary>
        [Field(tag: "C8")]
        public string Custom8 { get; set; }
        /// <summary>
        /// Caption
        /// </summary>
        [Field(tag: "CA")]
        public string Caption { get; set; }
        /// <summary>
        /// Call Number
        /// </summary>
        [Field(tag: "CN")]
        public string CallNumber { get; set; }
        /// <summary>
        /// Title of unpublished reference
        /// </summary>
        [Field(tag: "CP")]
        public string UnpublishedTitle { get; set; }
        /// <summary>
        /// Place Published
        /// </summary>
        [Field(tag: "CY")]
        public string PlacePublished { get; set; }
        /// <summary>
        /// Date
        /// </summary>
        [Field(tag: "DA", converterType: typeof(DateTimeNullableFieldConverter))]
        public DateTime? Date { get; set; }
        /// <summary>
        /// Name of Database
        /// </summary>
        [Field(tag: "DB")]
        public string Database { get; set; }
        /// <summary>
        /// DOI
        /// </summary>
        [Field(tag: "DO")]
        public string Doi { get; set; }
        /// <summary>
        /// Database Provider
        /// </summary>
        [Field(tag: "DP")]
        public string DatabaseProvider { get; set; }
        /// <summary>
        /// Editor
        /// </summary>
        [Field(tag: "ED", converterType: typeof(StringListFieldConverter))]
        public IEnumerable<string> Editors { get; set; }
        /// <summary>
        /// End Page
        /// </summary>
        [Field(tag: "EP")]
        public string EndPage { get; set; }
        /// <summary>
        /// Edition
        /// </summary>
        [Field(tag: "ET")]
        public string Edition { get; set; }
        /// <summary>
        /// Reference ID
        /// </summary>
        [Field(tag: "ID")]
        public string Id { get; set; }
        /// <summary>
        /// Issue number
        /// </summary>
        [Field(tag: "IS")]
        public string IssueNumber { get; set; }
        /// <summary>
        /// Alternate Title (this field is used for the abbreviated title of a book or journal name)
        /// </summary>
        [Field(tag: "JA", converterType: typeof(StringListFieldConverter))]
        public IEnumerable<string> JournalAbbreviatedTitles { get; set; }
        /// <summary>
        /// Journal/Periodical name: full format
        /// </summary>
        [Field(tag: "JF", converterType: typeof(StringListFieldConverter))]
        public IEnumerable<string> JournalFullTitles { get; set; }
        /// <summary>
        /// Journal/Periodical name
        /// </summary>
        [Field(tag: "JO", converterType: typeof(StringListFieldConverter))]
        public IEnumerable<string> JournalTitles { get; set; }
        /// <summary>
        /// Keywords
        /// </summary>
        [Field(tag: "KW", converterType: typeof(StringListFieldConverter))]
        public IEnumerable<string> Keywords { get; set; }
        /// <summary>
        /// Link to PDF
        /// </summary>
        [Field(tag: "L1")]
        public string PdfLink { get; set; }
        /// <summary>
        /// Link to Full-text
        /// </summary>
        [Field(tag: "L2")]
        public string FulltextLink { get; set; }
        /// <summary>
        /// Related Records
        /// </summary>
        [Field(tag: "L3")]
        public string RelatedRecordsLink { get; set; }
        /// <summary>
        /// Image(s)
        /// </summary>
        [Field(tag: "L4")]
        public string ImagesLink { get; set; }
        /// <summary>
        /// Language
        /// </summary>
        [Field(tag: "LA", converterType: typeof(StringListFieldConverter))]
        public IEnumerable<string> Languages { get; set; }
        /// <summary>
        /// Language
        /// </summary>
        [Field(tag: "LB")]
        public string Label { get; set; }
        /// <summary>
        /// Website Link
        /// </summary>
        [Field(tag: "LK")]
        public string WebsiteLink { get; set; }
        /// <summary>
        /// Number
        /// </summary>
        [Field(tag: "M1")]
        public string Number { get; set; }
        /// <summary>
        /// Miscellaneous
        /// </summary>
        [Field(tag: "M2")]
        public string Miscellaneous { get; set; }
        /// <summary>
        /// Type of Work
        /// </summary>
        [Field(tag: "M3")]
        public string TypeOfWork { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        [Field(tag: "N1")]
        public string Notes { get; set; }
        /// <summary>
        /// Number of Volumes
        /// </summary>
        [Field(tag: "NV")]
        public string NumberOfVolumes { get; set; }
        /// <summary>
        /// Original Publication
        /// </summary>
        [Field(tag: "OP")]
        public string OriginalPublication { get; set; }
        /// <summary>
        /// Publisher
        /// </summary>
        [Field(tag: "PB")]
        public string Publisher { get; set; }
        /// <summary>
        /// Publishing Place
        /// </summary>
        [Field(tag: "PP")]
        public string PublishingPlace { get; set; }
        /// <summary>
        /// Publication year
        /// </summary>
        [Field(tag: "PY", converterType: typeof(PublicationYearFieldConverter))]
        public int? PublicationYear { get; set; }
        /// <summary>
        /// Reviewed Item
        /// </summary>
        [Field(tag: "RI")]
        public string ReviewedItem { get; set; }
        /// <summary>
        /// Research Notes
        /// </summary>
        [Field(tag: "RN")]
        public string ResearchNotes { get; set; }
        /// <summary>
        /// Reprint Edition
        /// </summary>
        [Field(tag: "RP")]
        public string ReprintEdition { get; set; }
        /// <summary>
        /// Section
        /// </summary>
        [Field(tag: "SE")]
        public string Section { get; set; }
        /// <summary>
        /// ISBN/ISSN
        /// </summary>
        [Field(tag: "SN", converterType: typeof(StringListFieldConverter))]
        public IEnumerable<string> Codes { get; set; }
        /// <summary>
        /// Start Page
        /// </summary>
        [Field(tag: "SP")]
        public string StartPage { get; set; }
        /// <summary>
        /// Short Titles
        /// </summary>
        [Field(tag: "ST", converterType: typeof(StringListFieldConverter))]
        public IEnumerable<string> ShortTitles { get; set; }
        /// <summary>
        /// Primary Title
        /// </summary>
        [Field(tag: "TI,T1,T2,T3", converterType: typeof(RisRecordTitleListFieldConverter))]
        public IEnumerable<RisRecordTitle> Titles { get; set; }
        /// <summary>
        /// Translated Title
        /// </summary>
        [Field(tag: "TT", converterType: typeof(StringListFieldConverter))]
        public IEnumerable<string> TranslatedTitles { get; set; }
        /// <summary>
        /// URLs
        /// </summary>
        [Field(tag: "UR", converterType: typeof(StringListFieldConverter))]
        public IEnumerable<string> Urls { get; set; }
        /// <summary>
        /// Volume number
        /// </summary>
        [Field(tag: "VL")]
        public string VolumeNumber { get; set; }
        /// <summary>
        /// Primary Date
        /// </summary>
        [Field(tag: "Y1", converterType: typeof(DateTimeNullableFieldConverter))]
        public DateTime? PrimaryDate { get; set; }
        /// <summary>
        /// Access Date
        /// </summary>
        [Field(tag: "Y2", converterType: typeof(DateTimeNullableFieldConverter))]
        public DateTime? AccessDate { get; set; }

        public RisRecord()
        {
            Authors = new List<RisRecordAuthor>();
            Editors = new List<string>();
            JournalAbbreviatedTitles = new List<string>();
            JournalFullTitles = new List<string>();
            JournalTitles = new List<string>();
            Keywords = new List<string>();
            Keywords = new List<string>();
            Codes = new List<string>();
            ShortTitles = new List<string>();
            Titles = new List<RisRecordTitle>();
            TranslatedTitles = new List<string>();
        }
    }
}
