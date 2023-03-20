using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : StateMachineBehaviour
{
    BossBehavior bossBehavior;
    // Start is called before the first frame update
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo,int layerIndex)
    {
        bossBehavior = animator.GetComponent<BossBehavior>();
    }

    // Update is called once per frame
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossBehavior.ProjectileShoot();
    }
}
