using System;
using UnityEngine;

namespace v_hero
{
    public class ScreenManager : MonoBehaviour
    {
        [SerializeField]
        private AbstractScreen[] screens;

        private int currentScreen;

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
            if (screens.Length > 0)
            {
                currentScreen = 0;
                ShowScreen(currentScreen);
            }
        }

        public void ShowScreen(int screenIndex , object data = null , Action cb = null)
        {
            if (screenIndex >= 0 && screenIndex < screens.Length && screens[screenIndex] != null)
            {
                EnableScreen(screenIndex, data, cb);
            }
        }

        private void EnableScreen(int screenIndex , object data = null ,Action cb = null)
        {
            if (currentScreen == screenIndex) return;
            screens[currentScreen].OnHide();
            screens[currentScreen].gameObject.SetActive(false);
            if (cb != null) cb.Invoke();
            screens[screenIndex].gameObject.SetActive(true);
            screens[screenIndex].Onshow(data);
            currentScreen = screenIndex;
        }
    }
 
}
