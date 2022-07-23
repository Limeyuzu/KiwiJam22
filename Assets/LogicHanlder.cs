using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicHanlder : MonoBehaviour
{
    public Button selectLeftButton;
    public Button selectRightButton;
    public TMPro.TMP_Text tempText;

    public GameObject leftChar;
    public GameObject rightChar;
    public GameObject button1;
    public GameObject button2;

    public Sprite thishting;

    public BoxCollider leftOne;
    public BoxCollider rightOne;

    
    
      
    public int counter = 0;
    public int[] selectedVal = new int[4];
    // Start is called before the first frame update
    void Start()    
    {
        selectLeftButton.onClick.AddListener(LeftSelect);
        selectRightButton.onClick.AddListener(RightSelect);
        
        
    }


    // Update is called once per frame
    void Update()
    {

        tempText.text = "selected -> " + selectedVal[0] + " " + selectedVal[1] + " " + selectedVal[2] + " " + selectedVal[3] + " ";



        if (counter >= 4)
        {
            Debug.Log("finish");
            leftChar.SetActive(false);
            rightChar.SetActive(false);

            button1.SetActive(false);
            button2.SetActive(false);

        }

    }

    void LeftSelect()
    {
        Debug.Log("Left");
        selectedVal[counter] = 1;
        counter++;
        Debug.Log("Sprite Clicked1");
    }

    void RightSelect() 
    {
        Debug.Log("Right");
        selectedVal[counter] = 2;
        counter++;
        Debug.Log("Sprite Clicked2");
    }

    void removeButtons()
    {
        
    }
}

