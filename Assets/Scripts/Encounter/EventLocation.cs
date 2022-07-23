using UnityEngine;

namespace AdventureTogether
{
    public class EventLocation : MonoBehaviour, INamed
    {
        public string Name;
        public BaseCharacterAction Action;

        string INamed.Name => Name;
    }
}