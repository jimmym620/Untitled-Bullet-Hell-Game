using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionBehaviour : StateMachineBehaviour
{
    private Transform playerPos;
    TaximanAttack TA;
    Rigidbody2D rb;
    float speed = 0.5f;
    float distanceToPlayer;
    bool moving;
    Vector2 newPos;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        TA = animator.GetComponent<TaximanAttack>();
        rb = animator.GetComponent<Rigidbody2D>();

        distanceToPlayer = Vector2.Distance(playerPos.position, animator.GetComponent<Transform>().position);
        // Vector2 newPos = TA.repositionEnemy();
        // rb.position = Vector2.MoveTowards(rb.position, newPos, speed * Time.deltaTime);

    
        newPos = TA.repositionEnemy();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moving = true;

        if(moving && rb.position != newPos ){
            float step = speed * Time.fixedDeltaTime;
            rb.position = Vector2.MoveTowards(rb.position, newPos, step);

        }
        else {
            moving = false;
            rb.velocity = Vector2.zero;
        }

        animator.SetBool("Reposition", false);


        //IF DESTINATION REACHED, STOP MOVING


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }





    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
