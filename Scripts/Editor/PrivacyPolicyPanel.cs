using UnityEditor;
using UnityEngine;

namespace OneTwoPlay.PrivacyPolicy
{
    class PrivacyPolicyPanel : EditorWindow {
        
        [MenuItem("Tools/PrivacyPolicy Panel")]
        public void Init()
        {
            PrivacyPolicyPanel window = (PrivacyPolicyPanel)EditorWindow.GetWindow(typeof(PrivacyPolicyPanel));
            window.Show();
        }

        void OnGUI () {
            if (GUILayout.Button("make thingy")){
                //GameObject prefab = Resources.Load("...");
                //Instantiate(prefab, camera.current.position, Quaternion.identity);
            }
        }
    }
}