using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class ClumsyAttackAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] int Damage = 1;

        public override IEnumerator Act(INamed thisNamed, Party party, Character enemy, TextMeshProUGUI textOutput)
        {
            var random = Random.value;
            if ( random < 0.5f)
            {
                yield return textOutput.AddBattleText($"{thisNamed.Name} stumbles and fails to attack.");
                yield break;
            }
            var additionalDamage = 0;
            var attackDownEffect = ((Character)thisNamed).CharacterStatuses.FirstOrDefault(s => s.StatusEffect == StatusEffect.AttackDown);
            if (attackDownEffect != null)
            {
                additionalDamage += attackDownEffect.Value;
            }
            yield return textOutput.AddBattleText($"{thisNamed.Name} attacks {enemy.Name}: ", ActionTextDelaySeconds);
            yield return enemy.ReceiveAttack(Damage, textOutput);
        }
    }
}
