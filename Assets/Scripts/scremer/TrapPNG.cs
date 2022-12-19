using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPNG : MonoBehaviour
{
    private float cooldownTimer = Mathf.Infinity;
    private SpriteRenderer sprite;
    
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, -12, transform.position.z);
        
        PlayerTrap.TrapEvent.AddListener(Buu);
    }
    private void Update()
    {
       
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0f)
        {
            transform.position = new Vector3(transform.position.x, -12, transform.position.z);
            
        }
    }

    private void Buu()
    {
       
        transform.position = new Vector3(transform.position.x, -3/10, transform.position.z);
        
        
        cooldownTimer = 2f;
    }
}
