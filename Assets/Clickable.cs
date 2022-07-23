using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject imageToScale; 

    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");
    }

    private void OnMouseEnter()
    {
        Debug.Log("enter");
        imageToScale.transform.localScale.Set(1.1f, 1.1f, 0);

    }
    private void OnMouseExit()
    {
        Debug.Log("exit");
    }
}
