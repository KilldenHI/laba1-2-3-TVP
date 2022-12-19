using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Increase))]
public class InEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Increase increase = (Increase)target;
        increase.size= EditorGUILayout.Slider("size",increase.size, increase.min, increase.max);


       
    }
}
