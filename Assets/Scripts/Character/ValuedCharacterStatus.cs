using UnityEngine;

namespace AdventureTogether
{
    public class ValuedCharacterStatus : MonoBehaviour
    {
        public StatusEffect StatusEffect;
        public int Value;

        public string Name => $"{StatusEffect} {Value}";
    }
}
