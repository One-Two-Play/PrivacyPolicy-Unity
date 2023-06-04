using System;
using UnityEngine;

namespace OneTwoPlay.PrivacyPolicy.Example
{
    public class PrivacyPolicyAzerionView : MonoBehaviour
    {
        [SerializeField] private BaseSubView _main, _settings;
        private Action _saveAction;
        private PrivacyPolicySaveData _saveData;
        private PrivacyPolicy _privacyPolicy;

        public void Init(PrivacyPolicy privacyPolicy, PrivacyPolicySaveData saveData, Action saveAction)
        {
            _main.Hide();
            _settings.Hide();
            _saveAction = saveAction;
            _saveData = saveData;
            _privacyPolicy = privacyPolicy;
            OpenMenu();
        }

        private void OpenSettings()
        {
            _settings.Set(_privacyPolicy.settings, _saveData, _saveAction, null);
        }

        private void OpenMenu()
        {
            _main.Set(_privacyPolicy.main, _saveData, _saveAction, OpenSettings);
        }
    }
}
