using UnityEditor;
using UnityEngine;

namespace Whalepass
{
    public class WhalepassApiSettingsWindow : EditorWindow
    {
        [MenuItem("Whalepass/Api Settings")]
        public static void ShowWindow()
        {
            GetWindow<WhalepassApiSettingsWindow>("API Settings");
        }

        private void OnGUI()
        {
            var settings = AssetDatabase.LoadAssetAtPath<WhalepassSdkSettings>("Assets/Resources/WhalepassSdkSettings.asset");
            if (settings != null)
            {
                EditorGUILayout.BeginVertical();
                settings.apiKey = EditorGUILayout.TextField("API Key", settings.apiKey);
                settings.gameId = EditorGUILayout.TextField("Game ID", settings.gameId);
                settings.testBattlepassId = EditorGUILayout.TextField("Test Battlepass ID", settings.testBattlepassId);

                if (GUILayout.Button("Save"))
                {
                    EditorUtility.SetDirty(settings);
                    AssetDatabase.SaveAssets();
                }

                WhalepassSdkSettings.settings = settings;

                EditorGUILayout.EndVertical();
            }
            else
            {
                EditorGUILayout.LabelField("Settings not found.");
            }
        }
    }
}

