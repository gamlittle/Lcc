﻿using LccModel;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace LccEditor
{
    public class LccMenuItem
    {
        [MenuItem("Assets/工具箱/Excel表导出C# Json", false, 10)]
        public static void ExportClassAndJson()
        {
            ExcelExportUtil.ExportClassAndJson();
        }
        [MenuItem("Assets/工具箱/Excel表导出Protobuf", false, 11)]
        public static void ExportProtobuf()
        {
            ExcelExportUtil.ExportProtobuf();
        }
        [MenuItem("Assets/工具箱/按文件规则标记资源", false, 20)]
        public static void TagFileRule()
        {
            if (File.Exists("Assets/Editor/Runtime/Core/Util/AssetBundle/AssetBundleSetting.asset"))
            {
                AssetBundleSetting assetBundleSetting = AssetDatabase.LoadAssetAtPath<AssetBundleSetting>("Assets/Editor/Runtime/Core/Util/AssetBundle/AssetBundleSetting.asset");
                if (assetBundleSetting.assetBundleRuleList == null)
                {
                    assetBundleSetting.assetBundleRuleList = new List<AssetBundleRule>();
                }
                assetBundleSetting.assetBundleRuleList.Add(AssetBundleUtil.TagFileRule());
                assetBundleSetting.assetBundleDataList = AssetBundleUtil.BuildAssetBundleData(assetBundleSetting.assetBundleRuleList.ToArray());
            }
            else
            {
                AssetBundleSetting assetBundleSetting = ScriptableObject.CreateInstance<AssetBundleSetting>();
                assetBundleSetting.assetBundleRuleList = new List<AssetBundleRule>();
                assetBundleSetting.assetBundleRuleList.Add(AssetBundleUtil.TagFileRule());
                assetBundleSetting.assetBundleDataList = AssetBundleUtil.BuildAssetBundleData(assetBundleSetting.assetBundleRuleList.ToArray());
                AssetDatabase.CreateAsset(assetBundleSetting, "Assets/Editor/Runtime/Core/Util/AssetBundle/AssetBundleSetting.asset");
                AssetDatabase.Refresh();
            }
        }
        [MenuItem("Assets/工具箱/按文件夹规则标记资源", false, 21)]
        public static void TagDirectoryRule()
        {
            if (File.Exists("Assets/Editor/Runtime/Core/Util/AssetBundle/AssetBundleSetting.asset"))
            {
                AssetBundleSetting assetBundleSetting = AssetDatabase.LoadAssetAtPath<AssetBundleSetting>("Assets/Editor/Runtime/Core/Util/AssetBundle/AssetBundleSetting.asset");
                if (assetBundleSetting.assetBundleRuleList == null)
                {
                    assetBundleSetting.assetBundleRuleList = new List<AssetBundleRule>();
                }
                assetBundleSetting.assetBundleRuleList.Add(AssetBundleUtil.TagDirectoryRule());
                assetBundleSetting.assetBundleDataList = AssetBundleUtil.BuildAssetBundleData(assetBundleSetting.assetBundleRuleList.ToArray());
            }
            else
            {
                AssetBundleSetting assetBundleSetting = ScriptableObject.CreateInstance<AssetBundleSetting>();
                assetBundleSetting.assetBundleRuleList = new List<AssetBundleRule>();
                assetBundleSetting.assetBundleRuleList.Add(AssetBundleUtil.TagDirectoryRule());
                assetBundleSetting.assetBundleDataList = AssetBundleUtil.BuildAssetBundleData(assetBundleSetting.assetBundleRuleList.ToArray());
                AssetDatabase.CreateAsset(assetBundleSetting, "Assets/Editor/Runtime/Core/Util/AssetBundle/AssetBundleSetting.asset");
                AssetDatabase.Refresh();
            }
        }
        [MenuItem("Assets/工具箱/构建AssetBundle包", false, 22)]
        public static void BuildAssetBundle()
        {
            if (File.Exists("Assets/Editor/Runtime/Core/Util/AssetBundle/AssetBundleSetting.asset"))
            {
                AssetBundleSetting assetBundleSetting = AssetDatabase.LoadAssetAtPath<AssetBundleSetting>("Assets/Editor/Runtime/Core/Util/AssetBundle/AssetBundleSetting.asset");
                assetBundleSetting.buildId++;
                if (string.IsNullOrEmpty(assetBundleSetting.outputPath))
                {
                    assetBundleSetting.outputPath = "AssetBundles";
                }
                AssetBundleUtil.BuildAssetBundle(assetBundleSetting);
            }
        }
        [MenuItem("Assets/工具箱/热更Panel", false, 31)]
        public static void CreateHotfixPanel()
        {
            string pathName = $"{CreateScriptUtil.GetSelectedPath()}/NewHotfixPanel.cs";
            Texture2D icon = (Texture2D)EditorGUIUtility.IconContent("cs Script Icon").image;
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<CreateScriptUtil>(), pathName, icon, "Assets/Editor/Runtime/Core/Template/HotfixPanelTemplate.txt");
        }
        [MenuItem("Assets/工具箱/热更ViewModel", false, 32)]
        public static void CreateHotfixViewModel()
        {
            string pathName = $"{CreateScriptUtil.GetSelectedPath()}/NewHotfixViewModel.cs";
            Texture2D icon = (Texture2D)EditorGUIUtility.IconContent("cs Script Icon").image;
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<CreateScriptUtil>(), pathName, icon, "Assets/Editor/Runtime/Core/Template/HotfixViewModelTemplate.txt");
        }
        [MenuItem("Assets/工具箱/主工程Panel", false, 33)]
        public static void CreateModelPanel()
        {
            string pathName = $"{CreateScriptUtil.GetSelectedPath()}/NewModelPanel.cs";
            Texture2D icon = (Texture2D)EditorGUIUtility.IconContent("cs Script Icon").image;
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<CreateScriptUtil>(), pathName, icon, "Assets/Editor/Runtime/Core/Template/ModelPanelTemplate.txt");
        }
        [MenuItem("Assets/工具箱/主工程ViewModel", false, 34)]
        public static void CreateModelViewModel()
        {
            string pathName = $"{CreateScriptUtil.GetSelectedPath()}/NewModelViewModel.cs";
            Texture2D icon = (Texture2D)EditorGUIUtility.IconContent("cs Script Icon").image;
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<CreateScriptUtil>(), pathName, icon, "Assets/Editor/Runtime/Core/Template/ModelViewModelTemplate.txt");
        }
    }
}