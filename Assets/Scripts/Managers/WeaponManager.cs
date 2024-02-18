using UnityEngine;

namespace v_hero
{
    public class WeaponManager : MonoBehaviour
    {
        private Transform player = null;

        private void Start()
        {
            try
            {
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            }
            catch (System.Exception)
            {

                Debug.Log("Error In getting player ");
            }
            
        }

        public void PlaceBomb()
        {
            _ = WeaponFactory.CreateExplosive("dynamite", player);
        }
    }
}
