using System;
using UnityEngine;

namespace v_hero
{
    public  class ScreenManager : MonoBehaviour
    {
        [SerializeField]
        private AbstractScreen[] screens;

        [SerializeField]
        [Tooltip("Leave Empty to set first screen as default screen")]
        private AbstractScreen initialScreen;

        private AbstractScreen currentScreen;

        private static ScreenManager instance;

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<ScreenManager>();

                    if (instance == null)
                    {
                        GameObject container = new GameObject("ScreenManager");
                        instance = container.AddComponent<ScreenManager>();
                    }
                }

                return instance;
            }
        }

        private void Awake()
        {
            if (initialScreen != null)
            {
                currentScreen = null;
            }
            else
            {
                currentScreen = screens[0];
            }
        }

        public void ShowScreen(int ScreenIndex, params object[] parameters)
        {
            if (currentScreen != screens[ScreenIndex])
            {
                EnableScreen(ScreenIndex, parameters);
                
            }
        }

        private void EnableScreen(int ScreenIndex, object[] parameters)
        {
            currentScreen.OnHide();
            currentScreen.gameObject.SetActive(false);
            currentScreen = screens[ScreenIndex];
            currentScreen.gameObject.SetActive(true);
            currentScreen.Onshow(parameters);
        }

    }
}
