﻿using UnityEngine;

namespace LccModel
{
    public class ExecutionAnimationComponent : Component
    {
        public AnimationClip AnimationClip { get; set; }


        public override void Awake()
        {
            ((Entity)Parent).OnEvent(nameof(ExecutionEffect.TriggerEffect), OnTriggerExecutionEffect);
        }

        public void OnTriggerExecutionEffect(Entity entity)
        {
            Parent.GetParent<SkillExecution>().OwnerEntity.Publish(AnimationClip);
        }
    }
}