using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUNNER : MonoBehaviour
{
    private Rigidbody2D physic;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool isGraund = false;
    private bool checkJump = false;
    public Transform player;
    public float jumpforce = 3f;
    public float speed;
    public float agroDistance;
    public int damegeDistance;
    public int damege;

    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private Statesi State
    {
        get { return (Statesi)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }
    private void FixedUpdate()
    {
        CheckGraund();
    }
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
       
        if (distToPlayer < agroDistance )
        {
            
            StartHunting();
        }
        else
        {
            
            StopHunting();
        }
        if (isGraund && checkJump) { Jump(); checkJump = false; }
    }
    private void StartHunting()
    {
        State = Statesi.run;
        if (player.position.x < transform.position.x)
        {
            
            
            physic.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);
            
        }
        else if(player.position.x > transform.position.x)
        {
          
            physic.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(1, 1);
            
        }
    }
    private void StopHunting()
    {
         State = Statesi.idle;
        physic.velocity = new Vector2(0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "kub")
        {

            checkJump = true;
        }
    }

    
    private void Jump()
    {

      physic.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }
    private void CheckGraund()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGraund = collider.Length > 1;
        
    }
}
public enum Statesi
{
    idle,
    run
}