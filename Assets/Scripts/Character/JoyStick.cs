using UnityEngine;
using UnityEngine.EventSystems;
using static v_hero.GameConstant;

namespace v_hero
{
    public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {

        [SerializeField]
        private RectTransform joystickHandlle;
        [SerializeField]
        private RectTransform joystickRing;

        private Vector2 joystickStartPosition;
        //[SerializeField]
        private float JoystickRadius = 100f;
        private Vector2 inputDirection = Vector2.zero;
        private bool isJoystickPressed;

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position = eventData.delta;
            Vector2 newVec = position + new Vector2(JoystickRadius, JoystickRadius);
            Debug.Log("vector" + Vector2.ClampMagnitude(newVec, JoystickRadius));
            joystickHandlle.localPosition =  Vector2.ClampMagnitude(newVec, JoystickRadius);
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
            joystickHandlle.localPosition = joystickStartPosition;
            TIME.DoSlowMotion();

        }


        void Start()
        {
            JoystickRadius = joystickRing.rect.width/2;
            joystickStartPosition = joystickHandlle.localPosition;
            Debug.Log("joysrickRadius" + joystickStartPosition);
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
