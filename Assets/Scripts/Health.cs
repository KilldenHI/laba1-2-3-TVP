using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private Transform tr;
   public float currentHealth {get; private set;}
    private Animator anim;
    private bool dead = false;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();

    }

    public void TakeDamege(float _damege)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damege, 0, startingHealth);

        if (currentHealth >0)
        {
            anim.SetTrigger("hhurt");
           
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("hdie");
                // Player
                if (GetComponent<HeroMovement>() != null)             
                GetComponent<HeroMovement>().enabled = false;
                // Runner
                if (GetComponent<runnerMove>() != null)
                    GetComponent<runnerMove>().enabled = false;
                dead = true;
            }
        }
    }


}
