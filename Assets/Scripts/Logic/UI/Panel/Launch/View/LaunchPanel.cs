﻿using DG.Tweening;
using ET;
using System.IO;
using UnityEngine;

namespace LccModel
{
    public class LaunchPanel : APanelView<LaunchModel>
    {
        private static LaunchPanel _instance;
        private ETTask _tcs;
        public static LaunchPanel Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObjectEntity gameObjectEntity = GameEntity.Instance.AddChildren<GameObjectEntity, GameObject>(CreateGameObject("Prefab/Panel/LaunchPanel"));
                    _instance = gameObjectEntity.AddComponent<LaunchPanel>();
                }
                return _instance;
            }
        }
        public CanvasGroup BG;
        public static GameObject CreateGameObject(string path)
        {
            GameObject gameObject = Instantiate(path);
            RectTransform rect = gameObject.GetComponent<RectTransform>();
            rect.sizeDelta = Vector2.zero;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.pivot = new Vector2(0.5f, 0.5f);
            Vector2 anchorMin = Screen.safeArea.position;
            Vector2 anchorMax = Screen.safeArea.position + Screen.safeArea.size;
            anchorMin = new Vector2(anchorMin.x / Screen.width, anchorMin.y / Screen.height);
            anchorMax = new Vector2(anchorMax.x / Screen.width, anchorMax.y / Screen.height);
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            return gameObject;
        }
        public static GameObject Instantiate(string path)
        {
            GameObject asset = Resources.Load<GameObject>(path);
            GameObject gameObject = Object.Instantiate(asset, Objects.Canvas.transform);
            gameObject.name = Path.GetFileNameWithoutExtension(path);
            return gameObject;
        }
        public async ETTask ShowLaunchAnim()
        {
            if (_tcs == null)
            {
                _tcs = ETTask.Create();
                BG.DOFade(0, ViewModel.time).onComplete = OnComplete;
            }
            await _tcs;
        }
        public void OnComplete()
        {
            _instance = null;
            Object.Destroy(gameObject);
            _tcs.SetResult();
            _tcs = null;
        }
    }
}