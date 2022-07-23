using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public interface ICharacterAction
    {
        void Act(Character thisChar, Party party, Character target, TextMeshProUGUI textOutput);
    }

    public abstract class BaseCharacterAction : MonoBehaviour, ICharacterAction
    {
        public abstract void Act(Character thisChar, Party party, Character target, TextMeshProUGUI textOutput);
    }
}
