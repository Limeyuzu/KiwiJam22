using UnityEngine;

namespace AdventureTogether
{
    public class BackgroundRandomiser : MonoBehaviour
    {

        [SerializeField] bool IsBattle = false;
        // Start is called before the first frame update
        void Start()
        {
            GameObject todaysLocation;
            if (!IsBattle)
            {
                
                if (Random.value < 0.5f)
                {
                    todaysLocation = GameObject.Find("Oasis");
                }
                else
                {
                    todaysLocation = GameObject.Find("Small hut");
                }
                var todaysSprite = todaysLocation.GetComponent<SpriteRenderer>().sprite;
                GetComponent<SpriteRenderer>().sprite = todaysSprite;

                var eventLocation = FindObjectOfType<EventLocation>();
                eventLocation.Name = todaysLocation.name;
            }
            else
            {
                var value = Random.value;
                if (value< 0.33f)
                {
                    todaysLocation = GameObject.Find("Cave");
                }
                else if (value < 0.66f)
                {
                    todaysLocation = GameObject.Find("Forest");
                }
                else
                {
                    todaysLocation = GameObject.Find("River");
                }
                var todaysSprite = todaysLocation.GetComponent<SpriteRenderer>().sprite;
                GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite = todaysSprite;
            }


        }
    }
}