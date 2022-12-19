using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runnerMove : MonoBehaviour
{


    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float agroDistance;
    private Rigidbody2D physic;
    private Animator anim;
    private Vector3 initScale;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        initScale = transform.localScale;
    }
    private void Update()
    {

       
        float distToPlayer = Vector2.Distance(transform.position, player.position);
       
        if (distToPlayer < agroDistance)
        {
           
            StartHunting(1);
        }
        else
        {

            StopHunting();
        }
    }

    private void StartHunting(int _direction)
    {
        
        
        if (player.position.x < transform.position.x)
        {

            Moving(-1);
         

        }
        else if (player.position.x > transform.position.x)
        {
            Moving(1);
          

        }

    }
    private void Moving(int _direction)
    {
      
        transform.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y , initScale.z);
        transform.position = new Vector3(transform.position.x + Time.deltaTime * _direction * speed, transform.position.y, transform.position.z); 
    }
    
    private void StopHunting()
    {
        anim.SetBool("moving", false);
       
        physic.velocity = new Vector2(0, 0);
    }
}
