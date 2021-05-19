using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    public GameObject colorPicker;
    bool isOpen = false;

    public void ShowOrHide()
    {
        if(colorPicker != null)
        {
           colorPicker.SetActive(!isOpen);
           isOpen = !isOpen; 
        }
    }

    public void Hide()
    {
        colorPicker.SetActive(false);
        isOpen = false;  
    }
}
