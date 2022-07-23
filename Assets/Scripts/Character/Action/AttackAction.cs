using System.Collections;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class AttackAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] int Damage = 1;

        public override IEnumerator Act(Character thisChar, Party party, Character enemy, TextMeshProUGUI textOutput)
        {
            yield return textOutput.AddBattleText($"{thisChar.Name} attacks {enemy.Name}: ");
            yield return enemy.ReceiveAttack(Damage, textOutput);
        }
    }
}
