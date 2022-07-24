using UnityEngine;

namespace AdventureTogether
{
    public class EventLocation : MonoBehaviour, INamed
    {
        public string Name;
        public BaseCharacterAction Action;

        string INamed.Name => Name;

        void Start()
        {
            var location = GetComponent<EventLocation>();
            if (Random.value < 0.99f)
            {
                location.Action = GetComponent<GrantPartyStatusAction>();
            }
            else
            {
                location.Action = GetComponent<HealPartyAction>();
            }

            location.Action = GetComponent<GrantPartyStatusAction>();


        }
    }
}