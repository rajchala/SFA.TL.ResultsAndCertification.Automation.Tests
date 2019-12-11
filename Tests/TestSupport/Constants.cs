using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.TL.ResultsAndCertification.Automation.Tests.Tests.TestSupport
{
    public class Constants
    {
        public const String postCode = "B43 6JN";
        public const String skillArea = "Construction";
        public const String radius = "30 miles";
        public const String jobTitle = "Builder";
        public const String noOfPlacementsRequired = "3";
        public const String employerName = "Abacus Childrens Nurseries";
        public const String testEmployerNameForVerification = "Test Account DO NOT USE";
        public const String testName = "Shalini-ABC";
        public const String testEmail = "testEmail@fhgygy.com";
        public const String testPhoneNumber = "01234567890";
        public const String NoofPlacements = "At least 1";
        public const String expectedCount = "1";
        public const String ProvisionGapOptInFalse = "False";
        public const String ProvisionGapOptInNo = "Null";
        public const String NoofPlacementEntered = "At least 1";
        public const String InvalidUser = "InvalidUser";
        public const String InvalidPass = "InvalidPass";
        public const String postcodeNoResults = "G63 0AR";
        public const String postCodeNoResultInSpecifiedRoute = "TR1 1AF";
        public const String skillAreaNoResults = "Agriculture, environmental and animal care";
        public const String skillAreaNoResult = "Transport and logistics";
        public const String expectedskillAreaForNoResultsInAnySkillset = "any skill area";
        public const String radiusNoResults = "5 miles";
        public const String oneResultpostCode = "TR1 1AF";
        public const String oneResultskillArea = "Care services";
        public const String oneResultradius = "5 miles";
        public const String queryToGetQualificationMappedToService = "SELECT lar.LarId FROM LearningAimReference lar LEFT JOIN Qualification q ON lar.LarID = q.LarID WHERE q.LarID = lar.LarId";
        public const String queryToGetQualificationNotMappedToService = "SELECT lar.LarId FROM LearningAimReference lar LEFT JOIN Qualification q ON lar.LarID=q.LarID WHERE q.LarID IS NULL order by lar.Id desc";
        public const String Opportunity1Postcode = "B43 6JN";
        public const String Opportunity1JobRole = "None given";
        public const String Opportunity1StudentsWanted = "At least 1";
        public const String Opportunity1Providers = "1";
        public const String opportunity2Postcode = "B43 6JN";
        public const String opportunity2JobRole = "None given";
        public const String opportunity2StudentsWanted = "At least 1";
        public const String opportunity2Providers = "1";
        public const String opportunity2SkillArea = "Care services";
        public const string invalidUkprn = "Invalid";
    }
}
