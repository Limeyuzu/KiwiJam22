using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class BattleEncounter : MonoBehaviour
    {
        [SerializeField] Party Party;
        [SerializeField] Character Enemy;
        [SerializeField] TextMeshProUGUI BattleText;

        IEnumerator Start()
        {
            Party = FindObjectOfType<Party>();
            BattleText.text = "";
            yield return BattleText.AddBattleText($"You encounter {Enemy.Name}!", 3.0f);

            while (!Party.IsDefeated() && !Enemy.IsDefeated())
            {
                foreach (var character in Party.Characters)
                {
                    yield return character.PerformTurn(Party, Enemy, BattleText);
                }

                var enemyTarget = Party.Characters.First(c => !c.IsDefeated());
                yield return Enemy.PerformTurn(Party, enemyTarget, BattleText);
            }

            if (Enemy.IsDefeated())
            {
                yield return BattleText.AddBattleText($"You continue on your journey.", 3.0f);
            } 
            else if (Party.IsDefeated())
            {
                yield return BattleText.AddBattleText($"The party has fallen...", 3.0f);
            }
        }
    }
}
