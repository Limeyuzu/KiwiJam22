using System.Collections;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class LuckyAttackTargetAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] int Damage = 888;

        public override IEnumerator Act(INamed thisChar, Party party, Character enemy, TextMeshProUGUI textOutput)
        {
            yield return textOutput.AddBattleText($"{thisChar.Name} is blessed by the Gods, attacks {enemy.Name}: ", ActionTextDelaySeconds);
            yield return enemy.ReceiveAttack(Damage, textOutput);
        }
    }
}
