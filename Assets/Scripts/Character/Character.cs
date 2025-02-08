using UnityEngine;
using static v_hero.GameConstant;

namespace v_hero
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5f;

        private FixedJoystick fixedJoystick;

        void Start()
        {
            //EVENT.SubscribeEvent<Vector2>(GAME_EVENTS.MOVE.ToString(), Move);
            fixedJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        }

        void Update()
        {
            Vector2 movement = new Vector2(fixedJoystick.Horizontal, fixedJoystick.Vertical) * speed * Time.deltaTime;
            transform.Translate(Mathf.Clamp(movement.x, LevelManager.minX, LevelManager.maxX), Mathf.Clamp(movement.y, LevelManager.minY, LevelManager.maxY), transform.position.z);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, LevelManager.minX, LevelManager.maxX), Mathf.Clamp(transform.position.y, LevelManager.minY, LevelManager.maxY), transform.position.z);
        }
    }
}