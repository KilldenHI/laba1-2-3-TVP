using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = cist.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
        //.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        GetComponent<SpriteRenderer>().color = paintGM.colorCorect;
        transform.localScale = new Vector2(paintGM.scaleCor, paintGM.scaleCor);
        if (paintGM.toolType == "eraser") GetComponent<SpriteRenderer>().color = Color.white;
    }
}
