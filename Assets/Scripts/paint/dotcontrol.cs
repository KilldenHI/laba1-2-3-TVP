using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotcontrol : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = paintGM.colorCorect;
        GetComponent<Transform>().localScale = new Vector2(paintGM.scaleCor, paintGM.scaleCor);
    }
    private void OnMouseOver()
    {
        if (paintGM.toolType == "eraser" ) Destroy(gameObject);
    }
}
