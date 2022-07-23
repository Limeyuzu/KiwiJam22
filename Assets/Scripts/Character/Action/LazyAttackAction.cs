using UnityEngine;

namespace AdventureTogether
{
    public class LazyAttackAction : ICharacterAction
    {
        [SerializeField] int Damage = 1;

        public void ActOnOtherCharacter(Character thisChar, Character otherChar)
        {
            if (Random.value > 0.5)
            {
                otherChar.ReceiveAttack(Damage);
            } 
            else
            {
                // TODO indicate the character did nothing
            }
        }

        public void ActOnParty(Character thisChar, Party party)
        {
        }
    }
}
