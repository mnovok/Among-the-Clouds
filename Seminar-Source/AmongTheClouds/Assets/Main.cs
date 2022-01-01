using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 

public class Main : MonoBehaviour
{
    void CreateText()
    {
        string path = "Assets/StreamingAssets/Log.txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Login log \n\n");
        }

        string content = "Login date: " + System.DateTime.Now + "\n";

        File.AppendAllText(path, content); 
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
