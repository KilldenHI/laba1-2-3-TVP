using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int jumpforce;
    [SerializeField] private LayerMask graundLayer;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput; 

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput* speed, body.velocity.y);
        //sprite.flipX = horizontalInput < 0.0f;
        if (horizontalInput > 0.01f)
         transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
         transform.localScale = new Vector3(-1,1,1);

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();
        }
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }   
    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpforce);
            anim.SetTrigger("jump");
        }
    }   
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, graundLayer);
        return raycastHit.collider != null;
    }
    public bool canAttake()
    {
        return horizontalInput == 0 && isGrounded();
    }
}
