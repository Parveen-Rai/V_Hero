using System;

namespace v_hero
{
    public abstract class Ability
    {
        protected string abilityName;
        protected float abilityLimit = 100f;
        protected float abilityUseRate = 2f;
        protected float coolDownRate = 4f;
        protected float currentAbilityRate;
        protected int abilityLevel;
        //protected float 

        protected Ability(string name)
        {
            abilityName = name;
            currentAbilityRate = abilityLimit;
        }

        public abstract void UseAbility();

        public abstract void CoolDownAbility();

        public AbilityData GetAbilityData()
        {
            return new AbilityData
            {
                abilityName = abilityName,
                abilityLevel = abilityLevel,
                coolDownDuration = coolDownRate,
                abilityUseRate = abilityUseRate,
            };
        }

        public void SetAbilityData(AbilityData ability)
        {
            abilityName = ability.abilityName;
            abilityLevel = ability.abilityLevel;
            coolDownRate = ability.coolDownDuration;
            abilityUseRate = ability.abilityUseRate;
        }

        public bool CanUse()
        {
            if(currentAbilityRate > 0) 
            {
                return true;
            }
            return false;
        }
    }

    [Serializable]
    public struct AbilityData
    {
        public string abilityName;
        public int abilityLevel;
        public float coolDownDuration;
        public float abilityUseRate;

    }
}
