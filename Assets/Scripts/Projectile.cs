using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damege;
    [SerializeField] private CircleCollider2D boxColloder;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private float delay = 3f;
    private float direction;
    private Animator amin;
    private CircleCollider2D boxCollider;
    private Rigidbody2D body;
    private bool down = false;
    private Health enemyHealth;
    private float cooldownTimer;
    private void Awake()
    {
        amin = GetComponent<Animator>();
        boxCollider = GetComponent<CircleCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        cooldownTimer = delay;
    }
    private void Update()
    {
        Up();
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0f)
        {            
            amin.SetTrigger("boom");
            if (CheckBoom())
            {
                enemyHealth.TakeDamege(damege);
            }   
        }
    }  
    public void Up()
    {
        float pis = transform.localScale.x;
        if (!down)
        {
            body.velocity = new Vector2(pis, 1) * speed;            
            down = true;
        }       
    }
    private bool CheckBoom()
    {
        RaycastHit2D hite = Physics2D.CircleCast(boxColloder.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            colliderDistance, Vector2.left, 0, enemyLayer);

        if (hite.centroid != null) enemyHealth = hite.transform.GetComponent<Health>();
        return hite.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(boxColloder.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, colliderDistance);
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        
       

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction) localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

    }

    private void Deactivate()
    {
       gameObject.SetActive(false);
       cooldownTimer = delay;
       down = false;
    }
}
