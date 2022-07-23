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
            var random = Random.value;
            if ( random < 0.5f)
            {
                yield return textOutput.AddBattleText($"{thisChar.Name} stumbles and fails to attack.");
                yield break;
            }
            yield return textOutput.AddBattleText($"{thisChar.Name} attacks {enemy.Name}: ", ActionTextDelaySeconds);
            yield return enemy.ReceiveAttack(Damage, textOutput);
        }
    }
}
