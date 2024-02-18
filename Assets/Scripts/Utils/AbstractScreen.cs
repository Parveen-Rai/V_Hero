using System;
using UnityEngine;

namespace v_hero
{
    public abstract class AbstractScreen : MonoBehaviour
    {
        public abstract void Onshow(object data = null);

        public abstract void OnHide();
    }
}
