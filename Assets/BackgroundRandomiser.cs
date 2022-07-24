using UnityEngine;

namespace AdventureTogether
{
    public class BackgroundRandomiser : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameObject todaysLocation;
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
    }
}