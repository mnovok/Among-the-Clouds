using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAppear : MonoBehaviour
{
    public GameObject menu;
    private bool isShowing;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }
    }
}
