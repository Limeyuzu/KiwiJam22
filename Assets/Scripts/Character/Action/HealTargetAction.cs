using UnityEngine;

namespace AdventureTogether
{
    public class HealTargetAction : ICharacterAction
    {
        [SerializeField] int HealAmount = 1;

        public void ActOnOtherCharacter(Character thisChar, Character otherChar)
        {
            otherChar.ReceiveHealing(HealAmount);
        }

        public void ActOnParty(Character thisChar, Party party)
        {
        }
    }
}
