using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace v_hero.Utils
{
    public class TimeManager : MonoBehaviour
    {
        // singelton instance
        private static TimeManager instance;

        [SerializeField]
        private float slowDownFactor = 0.05f;
        // Get the singleton instance
        public static TimeManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<TimeManager>();

                    if (instance == null)
                    {
                        GameObject container = new GameObject("TimeManager");
                        instance = container.AddComponent<TimeManager>();
                    }
                }

                return instance;
            }
        }

        public void DoSlowMotion()
        {
            Time.timeScale = slowDownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.2f;
        }

        public void UndoSlowMotion()
        {
            Time.timeScale = 1f;
        }
    }
}
