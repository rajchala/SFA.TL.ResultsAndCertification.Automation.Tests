using System;
using System.Configuration;

namespace SFA.TL.ResultsAndCertification.Automation.Tests.Tests.TestSupport
{ 
    public class Configurator
    {
        private static Configurator configuratorInstance = null;

        private String _browser;
        private String _baseUrl;
        private String _matchingServiceConnectionString;
        private String _adminUserName;
        private String _adminUserPass;
        private String _standardUserName;
        private String _standardUserPass;
        private String _dualUserName;
        private String _dualUserPass;
        private String _nonAuthorisedUserName;
        private String _nonAuthorisedUserPass;

        private Configurator()
        {
            _browser = ConfigurationManager.AppSettings["Browser"];
            _baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            _matchingServiceConnectionString = ConfigurationManager.AppSettings["MatchingServiceConnectionString"];
            _adminUserName = ConfigurationManager.AppSettings["AdminUserName"];
            _adminUserPass = ConfigurationManager.AppSettings["AdminUserPass"];
            _standardUserName = ConfigurationManager.AppSettings["StandardUserName"];
            _standardUserPass = ConfigurationManager.AppSettings["StandardUserPass"];
            _dualUserName = ConfigurationManager.AppSettings["DualUserName"];
            _dualUserPass = ConfigurationManager.AppSettings["DualUserPass"];
            _nonAuthorisedUserName = ConfigurationManager.AppSettings["NonAuthorisedUserName"];
            _nonAuthorisedUserPass = ConfigurationManager.AppSettings["NonAuthorisedUserPass"];

        }

        public static Configurator GetConfiguratorInstance()
        {
            if (configuratorInstance == null)
            {
                configuratorInstance = new Configurator();
            }
            return configuratorInstance;
        }

        public String GetBrowser()
        {
            return _browser;
        }

        public String GetBaseUrl()
        {
            return _baseUrl;
        }

        public String GetMatchingServiceConnectionString()
        {
            return _matchingServiceConnectionString;
        }

        public String GetAdminUserName()
        {
            return _adminUserName;
        }

        public String GetAdminPassword()
        {
            return _adminUserPass;
        }

        public String GetDualUserName()
        {
            return _dualUserName;
        }

        public String GetDualPassword()
        {
            return _dualUserPass;
        }
        public String GetStandardUserName()
        {
            return _standardUserName;
        }

        public String GetStandardPassword()
        {
            return _standardUserPass;
        }

        public String GetNonAuthorisedUserName()
        {
            return _nonAuthorisedUserName;
        }

        public String GetNonAuthorisedUserPassword()
        {
            return _nonAuthorisedUserPass;
        }
    }
}