using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace v_hero.Weapon
{
    public class Dynamite : Explosive
    {
        // Start is called before the first frame update
        private void Start()
        {
            transform.DOScale(0.7f, 1f)
                .SetEase(Ease.InQuint)
                .SetLoops(-1, LoopType.Yoyo);
        }
        protected override void Explode()
        {

        }
    }
}
