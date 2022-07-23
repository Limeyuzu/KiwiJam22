using UnityEngine;

namespace AdventureTogether
{
    public class AttackAction : ICharacterAction
    {
        [SerializeField] int Damage = 1;

        public void Act(Character thisChar, Party party, Character enemy)
        {
            enemy.ReceiveAttack(Damage);
        }
    }
}
