using BehaviourTree;
using UnityEngine;

namespace v_hero.Enemy
{
    public class FallBackToAttackPos : Node
    {
        private readonly Animator animator;
        private readonly Transform transform;
        private readonly Vector3 fallBackPos;
        private const float fallBackSpeed = 0.5f;

        public FallBackToAttackPos(Transform _transform,Vector3 _fallBackPos)
        {
            this.animator = _transform.GetComponent<Animator>();
            this.transform = _transform;
            this.fallBackPos = _fallBackPos;
        }

        public override NodeStates Evaluate()
        {
            if (Vector3.Distance(transform.position, fallBackPos) <= 0.1)
            {
                state = NodeStates.SUCCESS;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, fallBackPos, fallBackSpeed * Time.deltaTime);
                animator.SetBool("Move",true);
                state = NodeStates.RUNNING;
            }
            return state;
        }
    }
}
