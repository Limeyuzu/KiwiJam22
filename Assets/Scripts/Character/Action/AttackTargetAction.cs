using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class AttackTargetAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] int Damage = 1;

        public override IEnumerator Act(INamed thisNamed, Party party, Character enemy, TextMeshProUGUI textOutput)
        {
            var additionalDamage = 0;
            if (thisNamed is Character)
            {
                var attackUpEffect = ((Character)thisNamed).CharacterStatuses.FirstOrDefault(s => s.StatusEffect == StatusEffect.AttackUp);
                if (attackUpEffect != null)
                {
                    additionalDamage += attackUpEffect.Value;
                }
                var attackDownEffect = ((Character)thisNamed).CharacterStatuses.FirstOrDefault(s => s.StatusEffect == StatusEffect.AttackDown);
                if (attackDownEffect != null)
                {
                    additionalDamage += attackDownEffect.Value;
                }
            }

            yield return textOutput.AddBattleText($"{thisNamed.Name} attacks {enemy.Name}: ", ActionTextDelaySeconds);
            yield return enemy.ReceiveAttack(Damage + additionalDamage, textOutput);
        }
    }
}
