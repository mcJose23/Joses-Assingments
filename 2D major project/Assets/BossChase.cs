using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : StateMachineBehaviour
{
    public float speed;
    Transform player;
    Rigidbody2D rb;
    BossBehavior bossBehavior;

    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        bossBehavior = animator.GetComponent<BossBehavior>();
        
    }

    // Update is called once per frame
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossBehavior.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        rb.MovePosition(newPos);
        float distance = Vector2.Distance(player.position, rb.position);

        if (distance < bossBehavior.attackRange && bossBehavior.Phase2 && !bossBehavior.Phase3 && !bossBehavior.isDead)
        {
            animator.SetTrigger("MeleeAttack");
        }
        else if (distance < bossBehavior.attackRange && bossBehavior.Phase2 && !bossBehavior.Phase3 && !bossBehavior.isDead)
        {
            animator.SetTrigger("Phase2Attack");
        }
        else if (distance < bossBehavior.attackRange && bossBehavior.Phase2 && !bossBehavior.Phase3 && !bossBehavior.isDead)
        {
            animator.SetTrigger("Phase3Attack");

        }
        else if (bossBehavior.isDead)
        {
            animator.SetTrigger("Dead");
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
