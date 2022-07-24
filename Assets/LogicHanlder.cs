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

    public GameObject button1;
    public GameObject button2;

    public TMPro.TMP_Text Char1Text;
    public TMPro.TMP_Text Char2Text;

    public Party Party;


    public List<GameObject> CHolder;    

      
    public int counter = 0;
    public int[] selectedVal = new int[4];
    
    private float xOffset = 1;

    private string[] names;

    List<GameObject> CharacterList;

    //list of prefabs


    // Start is called before the first frame update
    void Start()    
    {
        selectLeftButton.onClick.AddListener(LeftSelect);
        selectRightButton.onClick.AddListener(RightSelect);

        //create list of characters...
        //
        names = new string[6] { "char1", "tim2", "kale3", "jake4", "mixhale5", "mike6"};
        seedNewCharacters();
    }


    // Update is called once per frame
    void Update()
    {

        tempText.text = "selected -> " + selectedVal[0] + " " + selectedVal[1] + " " + selectedVal[2] + " " + selectedVal[3] + " ";



        if (counter >= 3)
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
        GameObject aa = GameObject.Find("Right" + (counter - 1));
        GameObject bb = GameObject.Find("Left" + (counter - 1));
        Destroy(aa);
        Party.Characters.Add(bb.GetComponent<Character>());
        bb.SetActive(false);
        bb.transform.position = new Vector3(xOffset * counter, 0);
        bb.transform.localScale = new Vector3(0.5f, 0.5f);
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

        GameObject aa = GameObject.Find("Left" + (counter - 1));
        GameObject bb = GameObject.Find("Right" + (counter - 1));
        Destroy(aa);
        Party.Characters.Add(bb.GetComponent<Character>());
        bb.SetActive(false);
        bb.transform.position = new Vector3(xOffset * counter, 0);
        bb.transform.localScale = new Vector3(0.5f, 0.5f);
        seedNewCharacters();
    }

    void removeButtons()
    {
        GameObject aa = GameObject.Find("Right" + (counter)); 
        GameObject bb = GameObject.Find("Left" + (counter));

        Destroy(aa);
        Destroy(bb);

        for (int i = 0; i < Party.transform.childCount; ++i)
        {
            Party.transform.GetChild(i).gameObject.SetActive(true); // or false
        }

    }


    void seedNewCharacters()
    {

        int Rand1 = Random.Range(0, CHolder.Count);
        int Rand2 = Random.Range(0, CHolder.Count);

        
        while (Rand1 == Rand2)
        {
            Rand2 = Random.Range(0, CHolder.Count);
        }
        Debug.Log(Rand1);
        Debug.Log(Rand2);


        GameObject LeftCharacterHolder = CHolder[Rand1];
        GameObject RightCharacterHolder = CHolder[Rand2];

        //CHolder.RemoveAt(Rand1);
        //CHolder.RemoveAt(Rand2);



        //make 2 new instaces of characters
        GameObject A = Instantiate(LeftCharacterHolder) as GameObject;
        A.name = "Left" + counter;
        A.transform.position = new Vector3(-2.5f, 0);
        A.transform.parent = Party.transform;

        GameObject B = Instantiate(RightCharacterHolder) as GameObject;
        B.name = "Right" + counter;
        B.transform.position = new Vector3(2.5f, 0);
        B.transform.parent = Party.transform;

        Char1Text.SetText(LeftCharacterHolder.GetComponent<Character>().Name + "\n Traits:" + LeftCharacterHolder.GetComponent<Character>().Traits);
        Char2Text.SetText(RightCharacterHolder.GetComponent<Character>().Name);

     }

}

