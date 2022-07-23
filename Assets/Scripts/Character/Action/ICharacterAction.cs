using System.Collections;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public interface ICharacterAction
    {
        IEnumerator Act(Character thisChar, Party party, Character target, TextMeshProUGUI textOutput);
    }

    public abstract class BaseCharacterAction : MonoBehaviour, ICharacterAction
    {
        public abstract IEnumerator Act(Character thisChar, Party party, Character target, TextMeshProUGUI textOutput);
    }
}
