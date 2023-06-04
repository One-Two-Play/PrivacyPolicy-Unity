using System;
using UnityEngine;

namespace OneTwoPlay.PrivacyPolicy.Example
{
    public abstract class BaseSubView : MonoBehaviour
    {
        public virtual void Set(object langData, PrivacyPolicySaveData saveData, Action saveAction, Action someAction)
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}