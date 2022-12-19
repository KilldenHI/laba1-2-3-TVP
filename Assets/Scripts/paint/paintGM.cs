using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintGM : MonoBehaviour
{
    public Transform baseDot;
    public KeyCode mouseleft;
    public KeyCode mouseRight;
    public static string toolType;
    public static Color colorCorect;
    public static int order;
    public static float scaleCor= 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (Input.GetKey(mouseleft))
        {
            Instantiate(baseDot, objPosition, baseDot.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Q)) scaleCor-=0.1f;
        if (Input.GetKeyDown(KeyCode.E)) scaleCor += 0.1f;


    }
}
