using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdventureTogether
{
    public class Character : MonoBehaviour
    {
        [SerializeField] int Hp = 10;
        public List<ICharacterAction> Actions;
        public List<CharacterTrait> Traits;

        public void PerformTurn(Party party, Character enemy)
        {
            if (Traits.Contains(CharacterTrait.Lazy) && Random.value < 0.5)
            {
                // does nothing
                return;
            }

            var actionToDo = Actions.First();
            actionToDo.Act(this, party, enemy);
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
