﻿using System.Collections.Generic;

namespace LccModel
{
    public class AttackAbility : Entity, IAbilityEntity
    {
        public CombatEntity OwnerEntity { get => GetParent<CombatEntity>(); set { } }
        public CombatEntity ParentEntity => GetParent<CombatEntity>();
        public bool Enable { get; set; }


        public override void Awake<P1>(P1 p1)
        {
            base.Awake(p1);

            var effects = new List<Effect>();
            var damageEffect = new DamageEffect();
            damageEffect.Enabled = true;
            damageEffect.EffectTriggerType = EffectTriggerType.Condition;
            damageEffect.CanCrit = true;
            damageEffect.DamageType = DamageType.Physic;
            damageEffect.DamageValueFormula = $"自身攻击力";
            effects.Add(damageEffect);
            AddComponent<AbilityEffectComponent, List<Effect>>(effects);

        }


        public void ActivateAbility()
        {
            Enable = true;
        }
        public void EndAbility()
        {
            Enable = false;
        }




        public Entity CreateExecution()
        {
            var execution = OwnerEntity.AddChildren<AttackExecution>(this);
            execution.AbilityEntity = this;
            return execution;
        }
    }
}