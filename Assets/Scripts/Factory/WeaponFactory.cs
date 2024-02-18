using UnityEngine;

namespace v_hero
{
    public class WeaponFactory
    {
        public static Explosive CreateExplosive(string explosiveType, Transform spawnPoint)
        {
            Explosive explosivePrefab = GetExplosivePrefab(explosiveType);
            if (explosivePrefab != null)
            {
                Explosive explosive = Object.Instantiate(explosivePrefab, spawnPoint.position, Quaternion.identity);
                return explosive;
            }
            return null;
        }


        private static Explosive GetExplosivePrefab(string explosiveType)
        {
            switch (explosiveType.ToLower())
            {
                case "dynamite":
                    return Resources.Load<Dynamite>("Explosives/dynamite");
                case "molotov":
                    return Resources.Load<Molotov>("Explosives/molotov");
                default:
                    Debug.Log("Unknown Explosive Type " + explosiveType);
                    return null;

            }
        }
    }
}
