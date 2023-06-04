using System;
using OneTwoPlay.PrivacyPolicy.Example;
using UnityEngine;

namespace OneTwoPlay.PrivacyPolicy
{
    public class PrivacyPolicyPopup : MonoBehaviour
    {
        public static event Action OnPopupEndEvent;
        public static bool WasShow { get; private set; } = false;

        private readonly string PP_DATA = "PrivacyPolicySaveData";
        
        [SerializeField] private bool _autoInit = true;
        [SerializeField] private PrivacyPolicyAzerionView _prefab;
        private PrivacyPolicyAzerionView _view;
        private PrivacyPolicy _privacyPolicy;
        private PrivacyPolicySaveData _saveData;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            WasShow = PlayerPrefs.GetString(PP_DATA, "") != "";
            _saveData = WasShow
                ? JsonUtility.FromJson<PrivacyPolicySaveData>(PlayerPrefs.GetString(PP_DATA, ""))
                : new PrivacyPolicySaveData();

            if (WasShow)
            {
                OnPopupEndEvent?.Invoke();
                Destroy(gameObject);
            }
            _privacyPolicy = Extension.GetPrivacyPolicyData();
        }

        private void Start()
        {
            if (_autoInit)
            {
                Init();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        public void Init()
        {
            Show();
        }

        public void Show()
        {
            if(_view != null)
                Destroy(_view.gameObject);
            gameObject.SetActive(true);
            _view = Instantiate(_prefab, transform);
            _view.Init(_privacyPolicy,_saveData, Save);
        }

        private void Save()
        {
            PlayerPrefs.SetString(PP_DATA, JsonUtility.ToJson(_saveData));
            gameObject.SetActive(false);
            WasShow = true;
            OnPopupEndEvent?.Invoke();
        }
    }

    [System.Serializable]
    public class PrivacyPolicySaveData
    {
        public bool PersonalAds = true;
        public bool PersonalContent = true;
    }
}