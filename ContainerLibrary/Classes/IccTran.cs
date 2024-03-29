﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ContainerLibrary.Classes
{
    /// <summary>
    /// Generated by Karen Payne's tool.
    ///
    /// IMPORTANT:
    /// The commented out attributes are for generating JSON
    /// using a unit test method in MobileClaimsTest.TransToJsonFile()
    /// which is currently marked as ignored, not to run as it will fail
    /// unless Id and Identifier properties have the DataMember attributes
    /// uncommented.
    ///
    /// [NotMapped] is needed on Identifier property as it does not exists in the table
    /// This is done for usage in several unit test not meant for a real app. 
    ///
    /// In a real solution we would never be flip-flopping around like this
    /// but for teaching this is fine.
    /// 
    /// </summary>
    public partial class IccTran
    {
        //[IgnoreDataMember]
        public decimal Id { get; set; }
        //[DataMember(Name = "Id")]
        [NotMapped]
        public int Identifier { get; set; }
        public string TrSsn { get; set; }
        public string TrAllDone { get; set; }
        public string TrBye { get; set; }
        public string TrChangePinInd { get; set; }
        public string TrClaimFo { get; set; }
        public DateTime? TrCompleteTime { get; set; }
        public string TrHrsWorked { get; set; }
        public string TrIcAcRoInd { get; set; }
        public string TrIpAddress { get; set; }
        public string TrIvrCode { get; set; }
        public string TrLanguageCode { get; set; }
        public DateTime? TrLastActivityTime { get; set; }
        public string TrMfInd { get; set; }
        public string TrNewHireInd { get; set; }
        public string TrPin { get; set; }
        public string TrPinTryNum { get; set; }
        public string TrQ1aOnCert { get; set; }
        public string TrQ1bOnCert { get; set; }
        public string TrQ1cOnCert { get; set; }
        public string TrQ2OnCert { get; set; }
        public string TrQ3aOnCert { get; set; }
        public string TrQ3bOnCert { get; set; }
        public string TrQ3cOnCert { get; set; }
        public string TrQ4OnCert { get; set; }
        public string TrQuitCode { get; set; }
        public string TrRtwDate { get; set; }
        public DateTime? TrSatDate { get; set; }
        public DateTime? TrStartTime { get; set; }
        public string TrTransType { get; set; }
        public string TrWagesEarned { get; set; }
        public string TrWeekClaimed { get; set; }
        public string TrWeekEndDate { get; set; }
        public string TrWorkSearchInd { get; set; }
        public string TrEbContact1 { get; set; }
        public string TrEbContact2 { get; set; }
        public string TrEbContact3 { get; set; }
        public string TrEbDate1 { get; set; }
        public string TrEbDate2 { get; set; }
        public string TrEbDate3 { get; set; }
        public string TrEbEmployer1 { get; set; }
        public string TrEbEmployer2 { get; set; }
        public string TrEbEmployer3 { get; set; }
        public string TrEbLocation1 { get; set; }
        public string TrEbLocation2 { get; set; }
        public string TrEbLocation3 { get; set; }
        public string TrEbTypeWork1 { get; set; }
        public string TrEbTypeWork2 { get; set; }
        public string TrEbTypeWork3 { get; set; }
        public string TrEbAddtl { get; set; }
        public string TrLastWeekClaimed { get; set; }
        public string TrLastReferer { get; set; }
        public string TrLastScreen { get; set; }
        public string TrProgramEndWeek { get; set; }
        public string TrLastRestartWeek { get; set; }
        public string TrLastError { get; set; }
        public string TrIpCountryCode { get; set; }
        public string TrQ34tOnCert { get; set; }
        public string TrQ44tOnCert { get; set; }
        public string TrQ54tOnCert { get; set; }
        public string TrEbResult1 { get; set; }
        public string TrEbResult2 { get; set; }
        public string TrEbResult3 { get; set; }
        public string TrActivityDate1 { get; set; }
        public string TrActivityDate2 { get; set; }
        public string TrActivityDate3 { get; set; }
        public string TrActivityDescr1 { get; set; }
        public string TrActivityDescr2 { get; set; }
        public string TrActivityDescr3 { get; set; }
        public string TrTloExceptionFlag { get; set; }
        public string TrUnionExceptionFlag { get; set; }
        public string TrTloUnionPrecheckFlag { get; set; }
        public decimal? TrGeoLatitude { get; set; }
        public decimal? TrGeoLongitude { get; set; }
        public string TrGeolocallowcdCode { get; set; }
        public string TrMobdevcdCode { get; set; }
        public string TrMobileFlag { get; set; }
        public string TrMobileUserAgent { get; set; }
        public string TrMobileOperatingSystem { get; set; }
        public string TrPeucMsgShownFlag { get; set; }
        public string TrLwaCertifyFlag { get; set; }
        public DateTime? TrLwaSentToMfDate { get; set; }
    }
}
