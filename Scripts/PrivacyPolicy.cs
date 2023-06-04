using System.Collections.Generic;

namespace OneTwoPlay.PrivacyPolicy
{
    
    [System.Serializable]
    public class PrivacyPolicy
    {
        public string locale;
        public PrivacyPolicyMain main;
        public PrivacyPolicySettings settings;
    }

    [System.Serializable]
    public class PrivacyPolicyMain
    {
        public string accept;
        public string acceptAll;
        public string settings;
        public string description;
    }

    [System.Serializable]
    public class PrivacyPolicySettings
    {
        public string title;
        public string personalisedContent;
        public string personalisedAds;
        public string rememberSettings;
        public string understandHow;
        public string socialMedia;
        public string description;
        public string learnMore;
        public string learnMoreUrl;
        public string privacyPolicy;
        public string privacyPolicyUrl;
        public string save;
        public List<PrivacyPolicyPartner> partners;
    }
    [System.Serializable]
    public class PrivacyPolicyPartner
    {
        public string name;
        public string url;
    }
}