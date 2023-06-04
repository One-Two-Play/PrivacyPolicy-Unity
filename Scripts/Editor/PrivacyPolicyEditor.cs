using UnityEditor;
using UnityEngine;

namespace OneTwoPlay.PrivacyPolicy
{
    //[CustomEditor(typeof(PrivacyPolicyPopup))]
    public class PrivacyPolicyEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            if(GUILayout.Button("PrivacyPolicy Editor")){
                PrivacyPolicyPanel window = (PrivacyPolicyPanel) EditorWindow.GetWindow( typeof(PrivacyPolicyPanel), false, "PrivacyPolicyPanel" );
                window.Init();
            }
        }
    }
}