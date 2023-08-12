using UnityEngine;
using v_hero.Utils;

namespace v_hero.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5f;
        private float minX, maxX, minY, maxY;
        private readonly float offset = 0.4f;
        void Start()
        {
            Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            minX = screenBounds.x + offset;
            maxX = -screenBounds.x - offset;
            minY = screenBounds.y + offset;
            maxY = -screenBounds.y - offset;
            EventManager.SubscribeEvent<Vector2>("moveInput", move);
        }

        void move(Vector2 input)
        {
            Vector2 movement = new Vector2(input.x, input.y) * speed * Time.deltaTime;
            transform.Translate(Mathf.Clamp(movement.x, minX, maxX), Mathf.Clamp(movement.y, minY, maxY), transform.position.z);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
        }
    }
}