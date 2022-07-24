using System.Collections;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class GrantTargetStatusAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] ValuedCharacterStatus GrantStatus;

        public override IEnumerator Act(INamed thisNamed, Party party, Character target, TextMeshProUGUI textOutput)
        {
            yield return textOutput.AddBattleText($"{thisNamed.Name} gives {GrantStatus.Name} to {target.Name}: ", ActionTextDelaySeconds);
            yield return target.ReceiveStatus(GrantStatus, textOutput);
        }
    }
}
