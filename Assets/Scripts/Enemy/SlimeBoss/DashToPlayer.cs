using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using v_hero.Character;

namespace v_hero.Enemy
{
    public class DashToPlayer : Node
    {
        private readonly Animator animator;
        private readonly Transform transform;
        private readonly Player player;

        public DashToPlayer(Transform _transform,Player _player)
        {
            transform = _transform;
            animator = _transform.GetComponent<Animator>();
            player = _player;
        }

        public override NodeStates Evaluate()
        {
            return base.Evaluate();
        }
    }
}
