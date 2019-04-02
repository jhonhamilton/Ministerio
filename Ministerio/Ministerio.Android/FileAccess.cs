using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Ministerio.Droid
{
    class FileAccess
    {
        public static string GetLocalFilePath(string filename)
        {
            var path = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal);
            var file = System.IO.Path.Combine(path, filename);
            return file;
        }

        public static bool ExistDirectory(string path)
        {
            return Directory.Exists(path);
        }

        public static void CreateDirectoryFilePath(string path)
        {
            Directory.CreateDirectory(path);
        }

        public static bool ExistFile(string path)
        {
            return File.Exists(path);
        }

        public static void CreateFile(string path)
        {
            File.Create(path);
        }

        public static void DeleteFile(string path)
        {
            if (ExistFile(path))
            {
                File.Delete(path);
            }
        }
    }
}