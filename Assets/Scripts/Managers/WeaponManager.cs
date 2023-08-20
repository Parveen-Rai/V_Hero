using UnityEngine;
using v_hero.Weapon;
using v_hero.Factory;

namespace v_hero.Managers
{
    public class WeaponManager : MonoBehaviour
    {
        private Transform player = null;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        public void PlaceBomb()
        {
            Explosive explosive = WeaponFactory.CreateExplosive("dynamite", player);
        }
    }
}
