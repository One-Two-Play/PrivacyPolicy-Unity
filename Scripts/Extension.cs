using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OneTwoPlay.PrivacyPolicy
{
    public static class Extension
    {
        public static string GetLocaleFromSystemLanguage()
        {
            SystemLanguage lang = Application.systemLanguage;
            string res = "EN";
            switch (lang)
            {
                case SystemLanguage.Chinese:
                    res = "ZH";
                    break;
                case SystemLanguage.Dutch:
                    res = "NL";
                    break;
                case SystemLanguage.English:
                    res = "EN";
                    break;
                case SystemLanguage.French:
                    res = "FR";
                    break;
                case SystemLanguage.German:
                    res = "DE";
                    break;
                case SystemLanguage.Indonesian:
                    res = "IN";
                    break;
                case SystemLanguage.Italian:
                    res = "IT";
                    break;
                case SystemLanguage.Japanese:
                    res = "JA";
                    break;
                case SystemLanguage.Korean:
                    res = "KO";
                    break;
                case SystemLanguage.Lithuanian:
                    res = "LT";
                    break;
                case SystemLanguage.Polish:
                    res = "PL";
                    break;
                case SystemLanguage.Portuguese:
                    res = "PT";
                    break;
                case SystemLanguage.Russian:
                    res = "RU";
                    break;
                case SystemLanguage.Spanish:
                    res = "ES";
                    break;
                case SystemLanguage.Swedish:
                    res = "SV";
                    break;
                case SystemLanguage.Turkish:
                    res = "TR";
                    break;
                case SystemLanguage.Unknown:
                    res = "EN";
                    break;
            }

            return res.ToLower();
        }
        
        public static PrivacyPolicy GetPrivacyPolicyData()
        {
            string currentLocale = GetLocaleFromSystemLanguage();
            string loadResourceTextFile = LoadResourceTextFile("PPandAG.json");
            PrivacyPolicyConfiguration allLocale = JsonUtility.FromJson<PrivacyPolicyConfiguration>(loadResourceTextFile);
            PrivacyPolicy privacyPolicy = new PrivacyPolicy();
            privacyPolicy = allLocale.privacyPolicies.FirstOrDefault(p => p.locale == currentLocale);
            if (privacyPolicy == null)
            {
                Debug.LogWarning($"PrivacyPolicy for \"{currentLocale}\" dont find!!!");
            }

            return privacyPolicy;
        }
        
        public static string LoadResourceTextFile(string path)
        {
 
            string filePath = "" + path.Replace(".json", "");
 
            TextAsset targetFile = Resources.Load<TextAsset>(filePath);
 
            return targetFile.text;
        }
        
        [System.Serializable]
        private class PrivacyPolicyConfiguration
        {
            public PrivacyPolicy[] privacyPolicies;
        }
    }
}