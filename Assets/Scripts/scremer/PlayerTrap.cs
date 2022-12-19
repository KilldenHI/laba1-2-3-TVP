using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrap : MonoBehaviour
{
    public static UnityEvent TrapEvent = new UnityEvent();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        { 
            TrapEvent.Invoke();
           
        }
    }
}
