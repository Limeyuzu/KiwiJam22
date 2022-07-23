using System.Collections;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class ClumsyAttackAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] int Damage = 1;

        public override IEnumerator Act(INamed thisChar, Party party, Character enemy, TextMeshProUGUI textOutput)
        {
            yield return textOutput.AddBattleText($"{thisChar.Name} stumbles and fails to attack: ");
        }
    }
}
