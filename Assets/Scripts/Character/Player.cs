using UnityEngine;
using v_hero.Utils;

namespace v_hero.Character
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5f;
      
        void Start()
        {
            EventManager.SubscribeEvent<Vector2>("moveInput", Move);
        }

        void Move(Vector2 input)
        {
            Vector2 movement = new Vector2(input.x, input.y) * speed * Time.deltaTime;
            transform.Translate(Mathf.Clamp(movement.x, LevelManager.minX, LevelManager.maxX), Mathf.Clamp(movement.y, LevelManager.minY, LevelManager.maxY), transform.position.z);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, LevelManager.minX, LevelManager.maxX), Mathf.Clamp(transform.position.y, LevelManager.minY, LevelManager.maxY), transform.position.z);
        }
    }
}