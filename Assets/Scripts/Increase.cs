using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Increase : MonoBehaviour
{
    [SerializeField] public float min= 0f;
    [SerializeField] public float max= 1f; 
    [SerializeField] public Transform obeckt;
    public float size;
    public float baseSize = 0.5937f;

    private void Awake()
    {
        obeckt.localScale = new Vector3(1, 1, 1) * baseSize;
        size = baseSize;
       
    }
    private void Update()
    {
        obeckt.localScale = new Vector3(1, 1, 1) * size;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            size = baseSize;
           
        }
    }










}
