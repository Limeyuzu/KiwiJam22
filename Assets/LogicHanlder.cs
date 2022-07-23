using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AdventureTogether;



public class LogicHanlder : MonoBehaviour
{
    public Button selectLeftButton;
    public Button selectRightButton;
    public TMPro.TMP_Text tempText;

    public GameObject leftChar;
    public GameObject rightChar;
    public GameObject button1;
    public GameObject button2;

    public TMPro.TMP_Text Char1Text;
    public TMPro.TMP_Text Char2Text;

    public Party Party;

    [SerializeReference] GameObject C1;    
    [SerializeReference] GameObject C2;    
    [SerializeReference] GameObject C3;    
    [SerializeReference] GameObject C4;    
    [SerializeReference] GameObject C5;    
    [SerializeReference] GameObject C6;    

      
    public int counter = 0;
    public int[] selectedVal = new int[4];

    private string[] names;
    


    //list of prefabs


    // Start is called before the first frame update
    void Start()    
    {
        selectLeftButton.onClick.AddListener(LeftSelect);
        selectRightButton.onClick.AddListener(RightSelect);

        //create list of characters....
        //
        names = new string[6] { "char1", "tim2", "kale3", "jake4", "mixhale5", "mike6"};
        seedNewCharacters();
    }


    // Update is called once per frame
    void Update()
    {

        tempText.text = "selected -> " + selectedVal[0] + " " + selectedVal[1] + " " + selectedVal[2] + " " + selectedVal[3] + " ";



        if (counter >= 100)
        {
            removeButtons();
            Debug.Log("finish");
            SceneLoader.LoadNextScene();
        }

    }

    public void LeftSelect()
    {
        //Debug.Log("Left");
        //selectedVal[counter] = 1;
        counter++;
        //GameObject createNew = new GameObject(Char1Text.text);
        //Instantiate(createNew);
        //createNew.transform.parent = Party.transform;
        //Character newcharacter = createNew.AddComponent<Character>() as Character;
        //newcharacter.Name = Char1Text.text;
        //Party.Characters.Add(newcharacter);
        GameObject aa = GameObject.Find("Right" + counter);
        Destroy(aa);
        seedNewCharacters();
    }

    public void RightSelect()       
    {
        //Debug.Log("Right");
        //selectedVal[counter] = 2;
        counter++;
        //GameObject createNew = new GameObject(Char2Text.text);
        //Instantiate(createNew);
        //createNew.transform.parent = Party.transform;
        //Character newcharacter = createNew.AddComponent<Character>() as Character;
        //newcharacter.Name = Char2Text.text;
        //Party.Characters.Add(newcharacter);

        GameObject aa = GameObject.Find("Left" + counter);
        Destroy(aa);
        seedNewCharacters();
    }

    void removeButtons()
    {
        
            leftChar.SetActive(false);
            rightChar.SetActive(false);

            button1.SetActive(false);
            button2.SetActive(false);
    }

    void seedNewCharacters()
    {

        Char1Text.SetText(names[Random.Range(0, 6)]);
        Char2Text.SetText(names[Random.Range(0, 6)]);

        float randomVal = Random.Range(0, 100);

        GameObject LeftCharacterHolder;
        GameObject RightCharacterHolder;

        if (randomVal <= 10)
        {
            LeftCharacterHolder = C1;
        }
        else if(randomVal <=20)
        {
            LeftCharacterHolder = C2;
        }
        else
        {
            LeftCharacterHolder = C3;
        }

        //make 2 new instaces of characters
        GameObject A = Instantiate(LeftCharacterHolder) as GameObject;
        A.name = "Left" + counter;
        A.transform.position = new Vector3(-2.5f, 0);
        A.transform.parent = Party.transform;

        GameObject B = Instantiate(C2) as GameObject;
        B.name = "Right" + counter;
        B.transform.position = new Vector3(2.5f, 0);
        B.transform.parent = Party.transform;
        
     }

}

