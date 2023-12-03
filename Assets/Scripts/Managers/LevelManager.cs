using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace v_hero
{
    public class LevelManager : MonoBehaviour
    {
        public static float minX, maxX, minY, maxY;
        private static readonly float offset = 0.4f;
        private static void SetUpScreenBounds()
        {
            Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            minX = screenBounds.x + offset;
            maxX = -screenBounds.x - offset;
            minY = screenBounds.y + offset;
            maxY = -screenBounds.y - offset;
        }
        // Start is called before the first frame update
        void Start()
        {
            SetUpScreenBounds();
        }
    }
}
