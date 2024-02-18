using UnityEngine;

namespace v_hero
{
    [CreateAssetMenu(fileName = "ExplosiveItem" ,menuName = "Inventory/ExplosiveItem")]
    public class ExplosiveData : ScriptableObject
    {
        public string explosiveName;
        public string description;
        public float baseDamage;
        public float baseDamagerRadius;
        public int maxUpgradeLevel;
        public float damageUpgradeMultiplier;
        public float damageRadiusUpgradeMultiplier;

    }
}
