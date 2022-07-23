using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class AttackAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] int Damage = 1;

        public override void Act(Character thisChar, Party party, Character enemy, TextMeshProUGUI textOutput)
        {
            enemy.ReceiveAttack(Damage, textOutput);
        }
    }
}
