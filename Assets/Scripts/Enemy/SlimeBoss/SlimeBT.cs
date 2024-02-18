using BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace v_hero
{
    public class SlimeBT : NodeTree, IEnemy
    {
        private float healthPoints;

        private bool isDead = false;

        private Vector3 InitialPos = new Vector3();
        public float HealthPoints
        {
            get { return healthPoints; }
        }

        protected override void Start()
        {
            base.Start();
            InitialPos = transform.position;
        }

        public bool IsDead { get { return isDead; } }

        public void InsaneAttack()
        {
            throw new System.NotImplementedException();
        }

        public void NormalAttack()
        {
            throw new System.NotImplementedException();
        }

        public void SpecialAttack()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateHealth(float health)
        {
            healthPoints -= health;
            if (healthPoints <= 0)
            {
                isDead = true;
            }
        }

        protected override Node SetUpTree()
        {
            Node root = new Selector(new List<Node> {
               new FallBackToAttackPos(transform,InitialPos)
            }
            );
            return root;
        }
    }
}
