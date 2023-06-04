using UnityEngine;
using UnityEngine.UI;

namespace OneTwoPlay.PrivacyPolicy.Example
{
    public class PartnerContainerView : MonoBehaviour
    {
        public Text titleLabel;
        public Text urlLabel;
        private string url;

        public void Setup(string title, string url)
        {
            this.url = url;
            titleLabel.text = title;
            urlLabel.text = url;
        }

        public void OnViewClicked()
        {
            Application.OpenURL(url);
        }
    }
}