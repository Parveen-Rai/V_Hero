using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace v_hero.Weapon
{
    public abstract class Explosive : MonoBehaviour
    {
        protected float damage;
        protected float explosionRadius;
        protected abstract void explode();
    }
}
