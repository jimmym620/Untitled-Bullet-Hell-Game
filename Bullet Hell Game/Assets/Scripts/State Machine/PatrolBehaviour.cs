using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    private Transform playerPos;
    public float speed;
    private float DirY;
    Rigidbody2D rb;
    TaximanAttack TA;
    private float proximityValue = 3.5f;
    public float horizontalSpeed;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        TA = animator.GetComponent<TaximanAttack>();

        DirY = TA.getDirection();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = new Vector2(-horizontalSpeed, 0);
        // DirY = TA.getDirection();

        // rb.velocity = new Vector2(rb.velocity.x, DirY * speed);

        float distanceToPlayer = Vector2.Distance(playerPos.position, animator.GetComponent<Transform>().position);
        
        if(distanceToPlayer <= proximityValue){
            rb.velocity = Vector2.zero;
            animator.SetTrigger("Shoot");
            
        }
        


    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = Vector2.zero;
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
