using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int BattlesDefeated = 0; 

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
