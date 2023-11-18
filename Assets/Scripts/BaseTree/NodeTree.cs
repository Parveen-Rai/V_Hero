using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

namespace v_hero.BaseTree
{
    public abstract class NodeTree : MonoBehaviour
    {
        private Node _root = null;

        protected virtual void Start()
        {
            _root = SetUpTree();
        }

        protected void Update()
        {
            if (_root != null)
            {
                _root.Evaluate();
            }
        }

        protected abstract Node SetUpTree();
    }
}
