using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace ToolsMenu.ProjectConfig
{
    public static class Folders
    {
        public static void CreateDefaultFolders(string path, string root, params string[] dir)
        {
            CreateDir(path, root, dir);
        }

        public static void CreateDefaultFolders(string path, params string[] dir)
        {
            CreateDir(path, dir);
        }

        private static void CreateDir(string path, string root, params string[] dir)
        {
            foreach (var newDirectory in dir)
            {
                Directory.CreateDirectory(Path.Combine(path, root, newDirectory));
            }
        }

        private static void CreateDir(string path, params string[] dir)
        {
            foreach (var newDirectory in dir)
            {
                Directory.CreateDirectory(Path.Combine(path, newDirectory));
            }
        }
    }
}