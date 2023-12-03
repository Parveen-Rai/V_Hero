using System;
using UnityEngine;

namespace v_hero
{
    public abstract class AbstractScreen : MonoBehaviour
    {
        public abstract void Onshow(params object[] parameters);

        public abstract void OnHide();
    }
}
