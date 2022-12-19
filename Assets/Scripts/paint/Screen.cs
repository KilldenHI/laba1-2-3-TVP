using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    [SerializeField]
    public Camera camera;
    public string path;
    [SerializeField] private bool showText = true;
    [SerializeField] private string directoryName = "Screen";
     private string mainPath = "";
    private string cName;
     private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        path = path + '/';
        mainPath = path + directoryName + "/";
        if (!Directory.Exists(mainPath))
        {
            Directory.CreateDirectory(mainPath);
        }
    }
    private IEnumerator SaveScreenshot(string name)
    {

        RenderTexture rt = camera.targetTexture;
        Texture2D sc = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
        yield return new WaitForSeconds(0.3f);
        showText = true;

        RenderTexture.active = rt;
        sc.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        byte[] bytes = sc.EncodeToPNG();
        string finalPath = mainPath + name + ".png";
        File.WriteAllBytes(finalPath, bytes);


        yield return new WaitForSeconds(2.3f);
        showText = false;
    }
    public void SaveS()
    {
        if (Input.GetKeyUp("s"))
        {
            i++;
            cName = "Screen " + i;
            StartCoroutine(SaveScreenshot(cName));
        }
    }
    // Update is called once per frame
    void Update()
    {
        SaveS();
    }
}
