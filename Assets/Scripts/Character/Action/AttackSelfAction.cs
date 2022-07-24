using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class AttackSelfAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] int Damage = 1;

        public override IEnumerator Act(INamed thisNamed, Party party, Character enemy, TextMeshProUGUI textOutput)
        {
            var additionalDamage = 0;
            var attackDownEffect = ((Character)thisNamed).CharacterStatuses.FirstOrDefault(s => s.StatusEffect == StatusEffect.AttackDown);
            if (attackDownEffect != null)
            {
                additionalDamage += attackDownEffect.Value;
            }

            yield return textOutput.AddBattleText($"{thisNamed.Name} hurt themself: ", ActionTextDelaySeconds);
            var thisCHar = (Character)thisNamed;
            yield return thisCHar.ReceiveAttack(Damage + additionalDamage, textOutput);
        }
    }
}
