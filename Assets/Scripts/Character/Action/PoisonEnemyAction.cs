using System.Collections;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class PoisionEnemyAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] ValuedCharacterStatus GrantStatus;

        public override IEnumerator Act(INamed thisNamed, Party party, Character target, TextMeshProUGUI textOutput)
        {
            yield return textOutput.AddBattleText($"{thisNamed.Name} poisons {target.Name}: ");
            yield return target.ReceiveStatus(GrantStatus, textOutput);
           
        }
    }
}

