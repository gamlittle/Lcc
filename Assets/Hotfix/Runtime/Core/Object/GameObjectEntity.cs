using UnityEngine;

namespace LccHotfix
{
    public class GameObjectEntity : AObjectBase
    {
        public GameObject gameObject;
        public override void Awake<P1>(P1 p1)
        {
            gameObject = p1 as GameObject;
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
            gameObject.SafeDestroy();
        }
    }
}