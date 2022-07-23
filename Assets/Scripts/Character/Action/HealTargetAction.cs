using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class HealTargetAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] int HealAmount = 1;

        public override void Act(Character thisChar, Party party, Character target, TextMeshProUGUI BattleText)
        {
            target.ReceiveHealing(HealAmount, BattleText);
        }
    }
}
