using System;
using UnityEngine;
using UnityEngine.UI;

namespace OneTwoPlay.PrivacyPolicy.Example
{
    public class PrivacyPolicyAzerionMainView : BaseSubView
    {
        [SerializeField] private Text _description, _acceptText, _settingsText, _rejectText;
        private Action _openSettings;
        private Action _saveAction;

        public override void Set(object langData, PrivacyPolicySaveData saveData, Action saveAction, Action someAction)
        {
            base.Set(langData, saveData, saveAction, someAction);
            PrivacyPolicyMain data = langData as PrivacyPolicyMain;
            _saveAction = saveAction;
            _openSettings = someAction;
            _description.text = data.description;
            _acceptText.text = data.accept;
            _settingsText.text = data.settings;
            _rejectText.text = data.acceptAll;
        }

        public void Accept()
        {
            _saveAction.Invoke();
        }
        
        public void Settings()
        {
            _openSettings?.Invoke();
            Hide();
        }
        public void RejectAll()
        {
            Accept();
        }
    }
}