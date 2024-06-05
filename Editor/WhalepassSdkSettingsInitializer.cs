using UnityEditor;
using UnityEngine;

namespace Whalepass
{
    [InitializeOnLoad]
    public class WhalepassSdkSettingsInitializer
    {
        static WhalepassSdkSettingsInitializer()
        {
            var assetPath = "Assets/Resources/WhalepassSdkSettings.asset";
            var directoryPath = System.IO.Path.GetDirectoryName(assetPath);

            if (!System.IO.Directory.Exists(directoryPath))
            {
                System.IO.Directory.CreateDirectory(directoryPath);
                AssetDatabase.Refresh(); // Make sure Unity recognizes the new directory
            }

            var settings = AssetDatabase.LoadAssetAtPath<WhalepassSdkSettings>(assetPath);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<WhalepassSdkSettings>();
                AssetDatabase.CreateAsset(settings, assetPath);
                AssetDatabase.SaveAssets();
            }
        }
    }

}
