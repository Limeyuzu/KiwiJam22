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

        private float ReceiveTextSpeedSeconds = 0.5f;

        public IEnumerator PerformTurn(Party party, Character enemy, TextMeshProUGUI textOutput)
        {
            if (IsDefeated())
            {
                yield break;
            }

            var random = Random.value;
            if (Traits.Contains(CharacterTrait.Lazy) && random < 0.3f)
            {
                yield return textOutput.AddBattleText($"{Name} dozes off... zzz...", 2.0f);
                yield break;
            }
            if (Traits.Contains(CharacterTrait.Scared) && random < 0.3f)
            {
                yield return textOutput.AddBattleText($"{Name} is too scared to move.");
                yield break;
            }

            if (Traits.Contains(CharacterTrait.Intimidate) && random < 0.1f)
            {
                //lower enemy attack
            }



            //check if poisioned

            foreach (var action in Actions)
            {
                if (Traits.Contains(CharacterTrait.Scared) && random < 0.3f)
                {
                    yield return textOutput.AddBattleText($"{Name} is too scared to move.");
                    yield break;
                }
                yield return action.Act(this, party, enemy, textOutput);
                if (enemy.IsDefeated())
                {
                    yield break;
                }
            }
        }

        public IEnumerator ReceiveAttack(int damage, TextMeshProUGUI textOutput)
        {
            if (IsDefeated())
            {
                yield break;
            }

            if (Traits.Contains(CharacterTrait.Fragile)) damage *= 2;

            var random = Random.value;
            if (Traits.Contains(CharacterTrait.Evasive) && random < 0.3f)
            {
                yield return textOutput.AddBattleText($"{Name} evaded the attack.", ReceiveTextSpeedSeconds);
                yield break;
            }

            yield return textOutput.AddBattleText($"{Name} receives {damage} damage.");
            Hp -= damage;

            if (IsDefeated())
            {
                yield return textOutput.AddBattleText($"{Name} falls.");
            }
        }

        public IEnumerator ReceiveHealing(int healedAmount, TextMeshProUGUI textOutput)
        {
            if (IsDefeated())
            {
                yield break;
            }

            yield return textOutput.AddBattleText($"{Name} recovers {healedAmount} HP.", ReceiveTextSpeedSeconds);
            Hp += healedAmount;
        }

        public IEnumerator ReceiveStatus(ValuedCharacterStatus status, TextMeshProUGUI textOutput)
        {
            if (IsDefeated())
            {
                yield break;
            }

            if (CharacterStatuses.Select(s => s.StatusEffect).Contains(status.StatusEffect))
            {
                CharacterStatuses.Remove(status);
            }

            yield return textOutput.AddBattleText($"{Name} receives {status.Name}.", ReceiveTextSpeedSeconds);
            CharacterStatuses.Add(status);
        }

        public bool IsDefeated() => Hp <= 0;

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
