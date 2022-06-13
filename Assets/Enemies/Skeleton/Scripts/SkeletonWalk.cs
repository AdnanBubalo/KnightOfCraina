using System.Collections;
using System.Collections.Generic;
using EnemyScripts;
using UnityEngine;

public class SkeletonWalk : StateMachineBehaviour
{
    private MeleeEnemyController controller;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponent<MeleeEnemyController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.MoveToPlayer();
        
        if (controller.CheckHit())
        {
            animator.SetBool("Walk", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.StopMoving();
    }
}