﻿using UnityEngine;

namespace LccModel
{
    public class Panel
    {
        private GameObject _gameObject;
        public PanelType Type
        {
            get; set;
        }
        public PanelState State
        {
            get; set;
        }
        public AObjectBase AObjectBase
        {
            get; set;
        }
        public GameObject gameObject
        {
            get
            {
                if (_gameObject == null)
                {
                    if (AObjectBase != null)
                    {
                        GameObjectEntity GameObjectEntity = AObjectBase.GetParent<GameObjectEntity>();
                        _gameObject = GameObjectEntity?.gameObject;
                    }
                }
                return _gameObject;
            }
        }
        public void OpenPanel()
        {
            if (!(gameObject != null ? gameObject.activeSelf : false))
            {
                State = PanelState.Open;
                gameObject.SetActive(true);
            }
        }
        public void ClosePanel()
        {
            if (!(gameObject != null ? gameObject.activeSelf : false))
            {
                State = PanelState.Close;
                gameObject.SetActive(false);
            }
        }
        public void ClearPanel()
        {
            if (AObjectBase != null)
            {
                AObjectBase.Parent.SafeDestroy();
            }
        }
    }
}