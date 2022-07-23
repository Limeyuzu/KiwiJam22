using System.Collections;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class GrantPartyStatusAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] ValuedCharacterStatus GrantStatus;

        public override IEnumerator Act(INamed thisNamed, Party party, Character target, TextMeshProUGUI textOutput)
        {
            yield return textOutput.AddBattleText($"{thisNamed.Name} grants {GrantStatus.Name} to the party: ", ActionTextDelaySeconds);
            foreach (var character in party.Characters)
            {
                yield return character.ReceiveStatus(GrantStatus, textOutput);
            }
        }
    }
}
