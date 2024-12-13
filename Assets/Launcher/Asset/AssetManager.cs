﻿using NPOI.SS.Formula.Functions;
using UnityEngine;
using YooAsset;
using Object = UnityEngine.Object;

namespace LccModel
{
    //Resources.UnloadAsset仅能释放非GameObject和Component的资源 比如Texture Mesh等真正的资源 对于由Prefab加载出来的Object或Component,则不能通过该函数来进行释放
    public class AssetManager : SingletonMono<AssetManager>
    {
        public const string DefaultPackage = "DefaultPackage";

        protected ResourcePackage Package => YooAssets.GetPackage(DefaultPackage);

        public void OnDestroy()
        {
            UnloadAllAssetsAsync();
        }


        public void UnloadAllAssetsAsync()
        {
            if (Package == null)
                return;
            Package.UnloadAllAssetsAsync();
        }
        public void UnloadUnusedAssetsAsync()
        {
            if (Package == null)
                return;
            Package.UnloadUnusedAssetsAsync();
        }

        public bool CheckLocationValid(string location)
        {
            if (Package == null)
                return false;
            return Package.CheckLocationValid(location);
        }

        public AssetHandle LoadAssetSync(string location)
        {
            return Package.LoadAssetSync(location);
        }

        public AssetHandle LoadAssetAsync(string location)
        {
            return Package.LoadAssetAsync(location);
        }

        public AllAssetsHandle LoadAllAssetsSync(string location)
        {
            return Package.LoadAllAssetsSync(location);
        }

        public AllAssetsHandle LoadAllAssetsAsync(string location)
        {
            return Package.LoadAllAssetsAsync(location);
        }


        //同步加载
        public T LoadRes<T>(GameObject loader, string location) where T : Object
        {
            return ResObject.LoadRes<T>(loader, location).GetAsset<T>();
        }

        //同步加载
        public GameObject LoadGameObject(string location, bool keepHierar = false)
        {
            return ResGameObject.LoadGameObject(location, keepHierar).ResGO;
        }
    }
}