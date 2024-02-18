using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

namespace v_hero
{
    public class DashToPlayer : Node
    {
        private readonly Animator animator;
        private readonly Transform transform;
        private readonly Character character;

        public DashToPlayer(Transform _transform,Character _character)
        {
            transform = _transform;
            animator = _transform.GetComponent<Animator>();
            character = _character;
        }

        public override NodeStates Evaluate()
        {
            return base.Evaluate();
        }
    }
}
