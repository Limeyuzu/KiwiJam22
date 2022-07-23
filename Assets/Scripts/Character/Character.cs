using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class Character : MonoBehaviour, INamed
    {
        public string Name;
        public List<BaseCharacterAction> Actions;
        public List<CharacterTrait> Traits;
        public List<ValuedCharacterStatus> CharacterStatuses;

        [SerializeField] int Hp = 10;

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
            if (Traits.Contains(CharacterTrait.Fragile)) damage *= 2;

            var random = Random.value;
            if (Traits.Contains(CharacterTrait.Evasive) && random < 1.0f)
            {
                yield return textOutput.AddBattleText($"{Name} evaded the attack.");
                yield break;
            }

            yield return textOutput.AddBattleText($"{Name} receives {damage} damage.");
            Hp -= damage;
        }

        public IEnumerator ReceiveHealing(int healedAmount, TextMeshProUGUI textOutput)
        {
            yield return textOutput.AddBattleText($"{Name} recovers {healedAmount} HP.");
            Hp += healedAmount;
        }

        public IEnumerator ReceiveStatus(ValuedCharacterStatus status, TextMeshProUGUI textOutput)
        {
            if (CharacterStatuses.Select(s => s.StatusEffect).Contains(status.StatusEffect))
            {
                CharacterStatuses.Remove(status);
            }

            yield return textOutput.AddBattleText($"{Name} receives {status.Name}.");
            CharacterStatuses.Add(status);
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
