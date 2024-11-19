using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyenemy : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    [SerializeField] private float ranger;
    [SerializeField] private float ColliderDistance;
    [SerializeField] private float ranger2;
    [SerializeField] private float ColliderDistance2;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxcollider;
    [SerializeField] private LayerMask playerlayer;
    private float cooldowntimer = Mathf.Infinity;
    [SerializeField] private AudioClip attacksound;
    private Animator anim;

    private playersat playerhealth;

    [SerializeField] private enemypatrol enemypatroll;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemypatroll = GetComponentInParent<enemypatrol>();
    }
    private void Update()
    {
        cooldowntimer += Time.deltaTime;
        if (playerinsight())
        {

            if (cooldowntimer >= attackcooldown)
            {
                //attack
                cooldowntimer = 0;
               
                anim.SetTrigger("attack1");

            }
        }
        if (playerinsight2())
        {

            if (cooldowntimer >= attackcooldown)
            {

                cooldowntimer = 0;
               
                anim.SetTrigger("attack2");

            }
        }
        if (enemypatroll != null)
        {
            enemypatroll.enabled = !playerinsight();
            enemypatroll.enabled = !playerinsight2();
        }
    }
    private bool playerinsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxcollider.bounds.center + transform.right * ranger * transform.localScale.x * ColliderDistance,
            new Vector3(boxcollider.bounds.size.x * ranger, boxcollider.bounds.size.y, boxcollider.bounds.size.z),
            0, Vector2.left, 0, playerlayer);
        if (hit.collider != null)
            playerhealth = hit.transform.GetComponent<playersat>();
        return hit.collider != null;
    }
    private bool playerinsight2()
    {
        RaycastHit2D hit2 = Physics2D.BoxCast(boxcollider.bounds.center + transform.right * ranger2 * transform.localScale.x * ColliderDistance2,
            new Vector3(boxcollider.bounds.size.x * ranger2, boxcollider.bounds.size.y, boxcollider.bounds.size.z),
            0, Vector2.left, 0, playerlayer);
        if (hit2.collider != null)
        {

            playerhealth = hit2.transform.GetComponent<playersat>();
        }
        return hit2.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxcollider.bounds.center + transform.right * ranger * transform.localScale.x * ColliderDistance,
            new Vector3(boxcollider.bounds.size.x * ranger, boxcollider.bounds.size.y, boxcollider.bounds.size.z));
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxcollider.bounds.center + transform.right * ranger2 * transform.localScale.x * ColliderDistance2,
            new Vector3(boxcollider.bounds.size.x * ranger2, boxcollider.bounds.size.y, boxcollider.bounds.size.z));

    }
    private void damageplayer()
    {
        if (playerinsight())
        {
            playerhealth.hurtss();
        }
        else if (playerinsight2())
        {
            playerhealth.hurtss();
        }
    }
}
