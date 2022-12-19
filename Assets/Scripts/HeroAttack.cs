using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    [SerializeField] private float atackCooldown;
    [SerializeField] private Transform firePoint ;
    [SerializeField] private GameObject[] granegs;
    
    private Animator anim;
    private HeroMovement heroMovement;
    private float cooldownTimer = Mathf.Infinity;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        heroMovement = GetComponent<HeroMovement>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(1) && cooldownTimer > atackCooldown && heroMovement.canAttake())
        {
            Attack();
            
        }
        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        
        
    }
    private void fullAttack()
    {
        granegs[FindGraneg()].transform.position = firePoint.position;       
        granegs[FindGraneg()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));      
    }

    private int FindGraneg()
    {
        for (int i = 0; i < granegs.Length; i++)
        {
            if (!granegs[i].activeInHierarchy)
                return i;
        }
        
        return 0;
    }
}
