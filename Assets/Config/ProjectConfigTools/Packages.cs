using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace ToolsMenu.ProjectConfig
{
    public static class Packages
    {
        public static async void SetupDefaultManifest() => await DoSetupDefaultManifest();

        private async static Task DoSetupDefaultManifest()
        {
            string content = await GetContent(Path.Combine(Application.dataPath, "../Assets/Config/ProjectConfigTools/defaultManifest.txt"));
            WriteToFile(Path.Combine(Application.dataPath, "../Packages/manifest.json"), content);
        }

        private static void WriteToFile(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }

        private async static Task<string> GetContent(string path)
        {
            using (var reader = new StreamReader(path, true))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static void AddUnityPackageTextMeshPro()
            => AddUnityPackage("textmeshpro");

        public static void AddUnityPackageIdeVsCode()
            => AddUnityPackage("ide.vscode");

        public static void AddUnityPackageDeviceSimulator()
            => AddUnityPackage("device-simulator");

        public static void AddUnityPackageNewInputSystem()
            => AddUnityPackage("inputsystem");


        public static void AddUnityPackageTerrain()
            => AddUnityPackage("terrain");

        public static void AddUnityPackagePostProcessing()
            => AddUnityPackage("postrocessing");

        public static void AddUnityPackageProBuilder()
            => AddUnityPackage("probuilder");

        public static void AddUnityPackageUnityRecorder()
        {
            AddUnityPackage("timeline");
            AddUnityPackage("recorder");
        }

        private static void AddUnityPackage(params string[] packageNames)
        {
            foreach (var packageName in packageNames)
            {
                UnityEditor.PackageManager.Client.Add("com.unity." + packageName);
            }
        }
    }
}