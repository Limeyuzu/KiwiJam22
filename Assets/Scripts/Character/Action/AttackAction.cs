using UnityEngine;

namespace AdventureTogether
{
    public class AttackAction : ICharacterAction
    {
        [SerializeField] int Damage = 1;

        public void ActOnOtherCharacter(Character thisChar, Character otherChar)
        {
            otherChar.ReceiveAttack(Damage);
        }

        public void ActOnParty(Character thisChar, Party party)
        {
        }
    }
}
