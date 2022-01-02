﻿using UnityEngine;

namespace LccModel
{
    public static class PathUtil
    {
        /// <summary>
        /// 获取路径
        /// </summary>
        /// <param name="type"></param>
        /// <param name="folders"></param>
        /// <returns></returns>
        public static string GetPath(PathType type, params string[] folders)
        {
            string path = string.Empty;
            string subPath = string.Empty;
            switch (type)
            {
                case PathType.DataPath:
                    path = Application.dataPath;
                    break;
                case PathType.StreamingAssetsPath:
                    path = Application.streamingAssetsPath;
                    break;
                case PathType.PersistentDataPath:
                    path = Application.persistentDataPath;
                    break;
            }
#if UNITY_EDITOR
            //编辑器模式下也可以直接创建
            if (folders.Length == 1 && folders[0].Contains("/"))
            {
                return GetPath(path, folders[0]);
            }
#endif
            //不是编辑器模式 只能在外部空间创建文件夹
            if (type == PathType.PersistentDataPath && folders.Length == 1 && folders[0].Contains("/"))
            {
                return GetPath(path, folders[0]);
            }
            for (int i = 0; i < folders.Length; i++)
            {
                if (i == folders.Length - 1)
                {
                    subPath = $"{subPath}{folders[i]}";
                }
                else
                {
                    subPath = $"{subPath}{folders[i]}/";
                }
#if UNITY_EDITOR
                //编辑器模式下也可以直接创建
                if (!string.IsNullOrEmpty(subPath))
                {
                    DirectoryUtil.CreateDirectory($"{path}/{subPath}");
                }
#else
                //不是编辑器模式 只能在外部空间创建文件夹
                if (type == PathType.PersistentDataPath && !string.IsNullOrEmpty(subPath))
                {
                    DirectoryUtil.CreateDirectory($"{path}/{subPath}");
                }
#endif
            }
            return $"{path}/{subPath}";
        }
        public static string GetPlatformForAssetBundle()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor:
                    return "Windows";
                case RuntimePlatform.OSXPlayer:
                case RuntimePlatform.OSXEditor:
                    return "OSX";
                case RuntimePlatform.Android:
                    return "Android";
                case RuntimePlatform.IPhonePlayer:
                    return "IOS";
                default:
                    return string.Empty;
            }
        }
        public static string GetPath(string path, string folder)
        {
            string[] folders = folder.Split('/');
            folder = folders[0];
            DirectoryUtil.CreateDirectory($"{path}/{folder}");
            string subPath = string.Empty;
            for (int i = 1; i < folders.Length; i++)
            {
                if (string.IsNullOrEmpty(folders[i])) continue;
                subPath = $"{subPath}{folders[i]}";
                DirectoryUtil.CreateDirectory($"{path}/{folder}/{subPath}");
                if (i == folders.Length - 1) continue;
                subPath = $"{subPath}/";
            }
            return $"{path}/{folder}/{subPath}";
        }
    }
}