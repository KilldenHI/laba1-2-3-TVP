using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runnerDH : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damege;
    [SerializeField] private BoxCollider2D boxColloder;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private runnerMove runnerMove;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    private Health playerHealth;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
              
                anim.SetTrigger("attack");
            }
        }
        
        
    }

   
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxColloder.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxColloder.bounds.size.x * range, boxColloder.bounds.size.y, boxColloder.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        if (hit.centroid != null) playerHealth = hit.transform.GetComponent<Health>();
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxColloder.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxColloder.bounds.size.x * range, boxColloder.bounds.size.y, boxColloder.bounds.size.z));
    }


    private void Damegepleyer()
    {
        if  (PlayerInSight())
        {
            playerHealth.TakeDamege(damege);
        }
    }
}
