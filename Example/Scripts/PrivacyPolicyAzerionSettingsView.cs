using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OneTwoPlay.PrivacyPolicy.Example
{
    public class PrivacyPolicyAzerionSettingsView : BaseSubView
    {
        [SerializeField] private Text _titleText,
            _description,
            _rememberText,
            _understandText,
            _socialText,
            _personalAdsText,
            _personalContentText,
            _privacyPolicyText,
            _learnMoreText,
            _acceptText;

        [SerializeField] private Toggle _personalAdsToggle, _personalContentToggle;
        [SerializeField] private Transform _partnerContainer;
        [SerializeField] private PartnerContainerView _partnerPrefab;

        private List<PartnerContainerView> _partnerList = new (); 
        private Action _saveAction;

        private string _ppURL, _lmURL;
        public override void Set(object langData, PrivacyPolicySaveData saveData, Action saveAction, Action someAction)
        {
            base.Set(langData, saveData, saveAction, someAction);
            _saveAction = saveAction;
            var data = langData as PrivacyPolicySettings;
            
            _titleText.text = data.title;
            _description.text = data.description;
            _rememberText.text = data.rememberSettings;
            _understandText.text = data.understandHow;
            _socialText.text = data.socialMedia;
            _personalAdsText.text = data.personalisedAds;
            _personalContentText.text = data.personalisedContent;
            _privacyPolicyText.text = data.privacyPolicy;
            _learnMoreText.text = data.learnMore;
            _acceptText.text = data.save;

            SetToggle(_personalAdsToggle, saveData.PersonalAds, value => saveData.PersonalAds = value);
            SetToggle(_personalContentToggle, saveData.PersonalContent, value => saveData.PersonalContent = value);

            SetPartners(data.partners);
            
            _ppURL = data.privacyPolicyUrl;
            _lmURL = data.learnMoreUrl;
        }

        private void SetPartners(List<PrivacyPolicyPartner> dataPartners)
        {
            if (_partnerList.Count >= 0)
            {
                foreach (var view in _partnerList)
                {
                    Destroy(view.gameObject);
                }
            }
            _partnerList = new ();
            foreach (var partner in dataPartners)
            {
                var item = Instantiate(_partnerPrefab, _partnerContainer);
                item.Setup(partner.name, partner.url);
                _partnerList.Add(item);
            }
        }

        public void Save()
        {
            _saveAction.Invoke();
        }

        public void PrivacyPolicyOpenURL()
        {
            Application.OpenURL(_ppURL);
        }
        
        public void LearnMoreOpenURL()
        {
            Application.OpenURL(_lmURL);
        }

        private static void SetToggle(Toggle toggle,bool value, UnityAction<bool> action)
        {
            toggle.isOn = value;
            toggle.onValueChanged = new Toggle.ToggleEvent();
            toggle.onValueChanged.AddListener(action);
        }
    }
}