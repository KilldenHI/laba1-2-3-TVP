using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dednorm : MonoBehaviour
{
    private AudioSource audioSorce;
    private void Awake()
    {
        audioSorce = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            audioSorce.Play();
            
        }
    }





}
