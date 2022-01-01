using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStop : MonoBehaviour
{
    public GameObject Canvas;

    public float time = 5; //Seconds to read the text

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, time);
        //CanvasStop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideCanvas()
    {
        Canvas.SetActive(false);
    }
}
