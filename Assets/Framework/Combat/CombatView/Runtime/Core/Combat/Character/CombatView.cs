using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LccModel
{
    public class CombatView : Entity
    {
        public GameObject GameObject => GetComponent<GameObjectComponent>().gameObject;
        public Transform Transform => GameObject.transform;

        public TransformViewComponent TransformViewComponent => GetComponent<TransformViewComponent>();
        public AnimationViewComponent AnimationViewComponent => GetComponent<AnimationViewComponent>();
        public AttributeViewComponent AttributeViewComponent => GetComponent<AttributeViewComponent>();


        public SkinViewComponent SkinViewComponent => GetComponent<SkinViewComponent>();



        public override void Awake()
        {
            base.Awake();


            AddComponent<TransformViewComponent>();
            AddComponent<AnimationViewComponent>();


            AddComponent<AttributeViewComponent>();


            AddComponent<SkinViewComponent>();


            AddChildren<HealthPointView>();
        }
    }
}