using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorpicker : MonoBehaviour
{
    private void OnMouseDown()
    {
        paintGM.colorCorect = GetComponent<SpriteRenderer>().color;
        paintGM.order += 1;
    }
}
