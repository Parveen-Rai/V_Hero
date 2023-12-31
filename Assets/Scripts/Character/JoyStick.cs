using UnityEngine;
using UnityEngine.EventSystems;
using v_hero.Utils;

namespace v_hero.Character
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
            TimeManager.Instance.UndoSlowMotion();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isJoystickPressed = false;
            joystickHandlle.position = joystickStartPosition;
            TimeManager.Instance.DoSlowMotion();

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
                EventManager.TriggerEvent<Vector2>("moveInput", inputDirection);
            }
        }
    }

}
