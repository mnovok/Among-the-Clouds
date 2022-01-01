using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;

public class FileManager : MonoBehaviour
{

    public Transform contentWindow;

    public GameObject recallTextObject;

    void Start()
    {
        string readFromFilePath = Application.streamingAssetsPath + "/Description.txt";

        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();

        foreach(string line in fileLines)
        {
            Instantiate(recallTextObject, contentWindow);
            recallTextObject.GetComponent<Text>().text = line;
        }
    }

}