using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace v_hero
{
    public abstract class PopUpBase : MonoBehaviour
    {
        public abstract void Onshow(object data);

        public abstract void OnHide();
    }
}
