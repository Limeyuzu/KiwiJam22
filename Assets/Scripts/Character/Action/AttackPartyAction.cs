using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class AttackPartyAction : BaseCharacterAction, ICharacterAction
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
            }

            yield return textOutput.AddBattleText($"{thisNamed.Name} attacks the party: ", ActionTextDelaySeconds);
            foreach (var target in party.Characters)
            {
                yield return target.ReceiveAttack(Damage + additionalDamage, textOutput);
            }
        }
    }
}
