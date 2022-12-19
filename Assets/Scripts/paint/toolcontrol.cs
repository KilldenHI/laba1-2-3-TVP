using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolcontrol : MonoBehaviour
{
   

    private void OnMouseDown()
    {
        if (gameObject.name == "erase")
        paintGM.toolType = "eraser";


        if (gameObject.name == "paint")
            paintGM.toolType = "pencil";
    }
}
