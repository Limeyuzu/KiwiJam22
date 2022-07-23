using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class Character : MonoBehaviour, INamed
    {
        public string Name;
        [SerializeField] int Hp = 10;
        public List<BaseCharacterAction> Actions;
        public List<CharacterTrait> Traits;

        string INamed.Name => Name;

        public IEnumerator PerformTurn(Party party, Character enemy, TextMeshProUGUI textOutput)
        {
            var random = Random.value;
            if (Traits.Contains(CharacterTrait.Lazy) && random < 0.8f)
            {
                yield return textOutput.AddBattleText($"{Name} dozes off.");
                yield break;
            }

            foreach (var action in Actions)
            {
                yield return action.Act(this, party, enemy, textOutput);
            }
        }

        public IEnumerator ReceiveAttack(int damage, TextMeshProUGUI textOutput)
        {
            yield return textOutput.AddBattleText($"{Name} receives {damage} damage.");
            Hp -= damage;
        }

        public IEnumerator ReceiveHealing(int healedAmount, TextMeshProUGUI textOutput)
        {
            yield return textOutput.AddBattleText($"{Name} recovers {healedAmount} HP.");
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
