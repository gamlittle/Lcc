﻿using Sirenix.OdinInspector;

namespace LccModel
{
    [Effect("治疗英雄", 20)]
    public class CureEffect : Effect
    {
        public override string Label => "治疗英雄";

        [ToggleGroup("Enabled"), LabelText("治疗取值")]
        public string CureValueFormula;
        public string CureValueProperty { get; set; }
    }
}