using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdventureTogether;

public class disableCharacters : MonoBehaviour
{

    public Party thisParty;
    // Start is called before the first frame update
    void Start()
    {
        thisParty = FindObjectOfType<Party>();
        for (int i = 0; i < thisParty.transform.childCount; ++i)
        {
            thisParty.transform.GetChild(i).gameObject.SetActive(false); // or false
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
