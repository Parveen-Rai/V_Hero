using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace v_hero
{
    public class PopUpManager : MonoBehaviour
    {
        [SerializeField]
        private PopUpBase[] popUps;

        private static PopUpManager instance;

        public static PopUpManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<PopUpManager>();

                    if (instance == null)
                    {
                        GameObject container = new GameObject("PopUpManager");
                        instance = container.AddComponent<PopUpManager>();
                    }
                }

                return instance;
            }
        }

        public void ShowPopup(int popupIndex,params object[] parameters)
        {
            if (popUps[popupIndex] != null)
            {
                EnablePopUp(popupIndex, parameters);
            }
        }

        private void EnablePopUp(int popupIndex, object[] parameters)
        {
            popUps[popupIndex].gameObject.SetActive(true);
            popUps[popupIndex].Onshow(parameters);
        }

        public void HidePopUp(int popupIndex)
        {
            popUps[popupIndex].OnHide();
            popUps[popupIndex].gameObject.SetActive(false);
        }

        public void HideAllPopups()
        {
            foreach(PopUpBase popup in popUps)
            {
                popup.OnHide();
                popup.gameObject.SetActive(false);
            }
        }
    }
}
