﻿using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LccEditor
{
    public abstract class AMenuEditorWindow<T> : OdinMenuEditorWindow where T : EditorWindow
    {
        public OdinMenuTree odinMenuTree;
        public AEditorWindowBase current;
        public List<AEditorWindowBase> aEditorWindowBaseList = new List<AEditorWindowBase>();
        public OdinMenuTree OdinMenuTree
        {
            get
            {
                if (odinMenuTree == null)
                {
                    odinMenuTree = new OdinMenuTree();
                    odinMenuTree.Config.DrawSearchToolbar = true;
                    odinMenuTree.Selection.SelectionChanged += OnSelectionChanged;
                }
                return odinMenuTree;
            }
        }
        public static void OpenEditorWindow(string title)
        {
            EditorWindow editorWindow = GetWindow<T>(title);
            editorWindow.position = new Rect(Screen.currentResolution.width / 2 - 500, Screen.currentResolution.height / 2 - 250, 1000, 500);
            editorWindow.Show();
        }
        protected override OdinMenuTree BuildMenuTree()
        {
            return OdinMenuTree;
        }
        public void OnSelectionChanged(SelectionChangedType selectionChangedType)
        {
            switch (selectionChangedType)
            {
                case SelectionChangedType.ItemRemoved:
                    break;
                case SelectionChangedType.ItemAdded:
                    if (OdinMenuTree.Selection.SelectedValue != null)
                    {
                        current = (AEditorWindowBase)OdinMenuTree.Selection.SelectedValue;
                        current.OnEnable();
                    }
                    break;
                case SelectionChangedType.SelectionCleared:
                    if (current != null)
                    {
                        current.OnDisable();
                        current = null;
                    }
                    break;
            }
        }
        public void AddAEditorWindowBase<EditorWindowBase>(string path, EditorIcon icon = null) where EditorWindowBase : AEditorWindowBase
        {
            AEditorWindowBase aEditorWindowBase = (AEditorWindowBase)Activator.CreateInstance(typeof(EditorWindowBase), new object[] { this });
            if (icon == null)
            {
                OdinMenuTree.Add(path, aEditorWindowBase);
            }
            else
            {
                OdinMenuTree.Add(path, aEditorWindowBase, icon);
            }
            aEditorWindowBaseList.Add(aEditorWindowBase);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            foreach (AEditorWindowBase item in aEditorWindowBaseList)
            {
                item.OnDisable();
            }
            aEditorWindowBaseList.Clear();
        }
    }
}