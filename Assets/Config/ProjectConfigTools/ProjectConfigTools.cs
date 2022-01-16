using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace ToolsMenu.ProjectConfig
{
    public static class ProjectFoldersTools
    {
        [MenuItem("Tools/Setup/Create Default Assets Folders")]
        private static void CreateDefaultAssetsFolders()
        {
            Folders.CreateDefaultFolders(Application.dataPath, ProjectFolders.assetsFolders);
        }

        /// <summary>
        //Project Root folders setup
        //Art folder setup
        //Audio folder setup
        //Prefabs folder setup
        //Scripts folder setup
        /// </summary>
        [MenuItem("Tools/Setup/Create Default Project Folders")]
        private static void CreateDefaultProjectFolders()
        {
            Folders.CreateDefaultFolders(Application.dataPath, "_Project", ProjectFolders.projectRootFolders);
            Folders.CreateDefaultFolders(Application.dataPath, "_Project/Art", ProjectFolders.artFolders);
            Folders.CreateDefaultFolders(Application.dataPath, "_Project/Audio", ProjectFolders.audioFolders);
            CreatePrefabsFolders();
            Folders.CreateDefaultFolders(Application.dataPath, "_Project/Scripts", ProjectFolders.scriptsFolders);


            void CreatePrefabsFolders()
            {
                Folders.CreateDefaultFolders(Application.dataPath, "_Project/Prefabs", ProjectFolders.prefabsFolders);
                Folders.CreateDefaultFolders(Application.dataPath, "_Project/Prefabs/Props", ProjectFolders.prefabsPropsFolders);
            }
        }

        [MenuItem("Tools/Setup/Create MVP Project Folders")]
        private static void CreateMVPProjectFolders()
        {
            Folders.CreateDefaultFolders(Application.dataPath, "_Project/Scripts", ProjectFolders.mvpScriptsFolders);
            Folders.CreateDefaultFolders(Application.dataPath, "_Project/Scripts/_Presenter", ProjectFolders.presenterFolders);
        }
    }

    public static class ProjectPackagesTools
    {
        [MenuItem("Tools/Setup/Create Default Packages Manifest")]
        private static void SetupDefaultManifest() =>
            Packages.SetupDefaultManifest();


        [MenuItem("Tools/Packages/Default Unstable Packages/Add TextMeshPro")]
        public static void AddUnityPackageTextMeshPro() =>
            Packages.AddUnityPackageTextMeshPro();

        [MenuItem("Tools/Packages/Default Unstable Packages/Add IdeVsCode")]
        public static void AddUnityPackageIdeVsCode() =>
            Packages.AddUnityPackageIdeVsCode();

        [MenuItem("Tools/Packages/Default Unstable Packages/Add DeviceSimulator")]
        public static void AddUnityPackageDeviceSimulator() =>
            Packages.AddUnityPackageDeviceSimulator();

        [MenuItem("Tools/Packages/Default Unstable Packages/Add NewInputSystem")]
        public static void AddUnityPackageNewInputSystem() =>
            Packages.AddUnityPackageNewInputSystem();

        [MenuItem("Tools/Packages/Other/Add Terrain")]
        private static void AddTerrain() =>
            Packages.AddUnityPackageTerrain();

        [MenuItem("Tools/Packages/Other/Add PostProcessing")]
        private static void AddPostProcessing() =>
            Packages.AddUnityPackagePostProcessing();

        [MenuItem("Tools/Packages/Other/Add ProBuilder")]
        private static void AddUnityPackageProBuilder() =>
            Packages.AddUnityPackageProBuilder();

        [MenuItem("Tools/Packages/Other/Add UnityRecorder")]
        private static void AddUnityPackageUnityRecorder() =>
            Packages.AddUnityPackageUnityRecorder();
    }
}