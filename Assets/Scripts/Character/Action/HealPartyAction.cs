using System.Collections;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class HealPartyAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] int HealAmount = 1;

        public override IEnumerator Act(INamed thisNamed, Party party, Character target, TextMeshProUGUI textOutput)
        {
            yield return textOutput.AddBattleText($"{thisNamed.Name} heals the party: ", ActionTextDelaySeconds);
            foreach (var character in party.Characters)
            {
                yield return character.ReceiveHealing(HealAmount, textOutput);
            }
        }
    }
}
