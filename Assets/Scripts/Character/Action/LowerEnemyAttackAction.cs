using System.Collections;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class LowerEnemyAttackAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] ValuedCharacterStatus GrantStatus;

        public override IEnumerator Act(INamed thisNamed, Party party, Character target, TextMeshProUGUI textOutput)
        {
            yield return textOutput.AddBattleText($"{thisNamed.Name} intimidates {target.name}, their attack is lowered: ", ActionTextDelaySeconds);
            yield return target.ReceiveStatus(GrantStatus, textOutput);
            
        }
    }
}
