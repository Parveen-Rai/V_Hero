using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace v_hero
{
    public abstract class PopUpBase : MonoBehaviour
    {
        public abstract void Onshow(params object[] parameters);

        public abstract void OnHide();
    }
}
