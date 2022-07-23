using System.Collections.Generic;
using UnityEngine;

namespace AdventureTogether
{
    public class Character : MonoBehaviour
    {
        [SerializeField] int Hp = 10;
        public List<ICharacterAction> Actions;
        public List<ICharacterTrait> Traits;

        public void PerformTurn(Character enemy)
        {
            foreach (var action in Actions)
            {
                action.ActOnOtherCharacter(this, enemy);
            }
        }

        public void ReceiveAttack(int damage)
        {
            Hp -= damage;
        }

        public void ReceiveHealing(int healedAmount)
        {
            Hp += healedAmount;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
