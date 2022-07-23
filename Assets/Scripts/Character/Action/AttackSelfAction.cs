using System.Collections;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class AttackSelfAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] int Damage = 1;

        public override IEnumerator Act(INamed thisNamed, Party party, Character enemy, TextMeshProUGUI textOutput)
        {
            yield return textOutput.AddBattleText($"{thisNamed.Name} hurt themself: ");
            var thisCHar = (Character)thisNamed;
            yield return thisCHar.ReceiveAttack(Damage, textOutput);
        }
    }
}
