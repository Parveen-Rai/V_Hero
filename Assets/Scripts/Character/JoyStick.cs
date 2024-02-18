using UnityEngine;
using UnityEngine.EventSystems;
using static v_hero.GameConstant;

namespace v_hero
{
    public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {

        [SerializeField]
        private RectTransform joystickHandlle;
        private RectTransform joystickRing;

        private Vector2 joystickStartPosition;
        [SerializeField]
        private float JoystickRadius = 100f;
        private Vector2 inputDirection = Vector2.zero;
        private bool isJoystickPressed;

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position = eventData.position - joystickStartPosition;
            joystickHandlle.position = joystickStartPosition + Vector2.ClampMagnitude(position, JoystickRadius);
            inputDirection = position.normalized;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isJoystickPressed = true;
            TIME.UndoSlowMotion();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isJoystickPressed = false;
            joystickHandlle.position = joystickStartPosition;
            TIME.DoSlowMotion();

        }


        void Start()
        {
            joystickRing = joystickHandlle.parent.gameObject.GetComponent<RectTransform>();
            joystickStartPosition = joystickHandlle.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (isJoystickPressed)
            {
                EVENT.TriggerEvent(GAME_EVENTS.MOVE.ToString(), inputDirection);
            }
        }
    }

}
