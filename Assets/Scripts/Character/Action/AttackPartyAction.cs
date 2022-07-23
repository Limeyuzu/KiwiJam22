using System.Collections;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class AttackPartyAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] int Damage = 1;

        public override IEnumerator Act(INamed thisNamed, Party party, Character enemy, TextMeshProUGUI textOutput)
        {
            yield return textOutput.AddBattleText($"{thisNamed.Name} attacks the party: ");
            foreach (var target in party.Characters)
            {
                yield return target.ReceiveAttack(Damage, textOutput);
            }
        }
    }
}
