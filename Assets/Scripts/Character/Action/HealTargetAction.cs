using UnityEngine;

namespace AdventureTogether
{
    public class HealTargetAction : ICharacterAction
    {
        [SerializeField] int HealAmount = 1;

        public void Act(Character thisChar, Party party, Character target)
        {
            target.ReceiveHealing(HealAmount);
        }
    }
}
