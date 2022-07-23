using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class Character : MonoBehaviour
    {
        public string Name;
        [SerializeField] int Hp = 10;
        public List<BaseCharacterAction> Actions;
        public List<CharacterTrait> Traits;

        public void PerformTurn(Party party, Character enemy, TextMeshProUGUI textOutput)
        {
            if (Traits.Contains(CharacterTrait.Lazy) && Random.value < 0.5)
            {
                // does nothing
                return;
            }

            var actionToDo = Actions.First();
            actionToDo.Act(this, party, enemy, textOutput);
        }

        public void ReceiveAttack(int damage, TextMeshProUGUI textOutput)
        {
            textOutput.AddBattleText($"{Name} receives {damage} damage.");
            Hp -= damage;
        }

        public void ReceiveHealing(int healedAmount, TextMeshProUGUI textOutput)
        {
            textOutput.AddBattleText($"{Name} recovers {healedAmount} HP.");
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
