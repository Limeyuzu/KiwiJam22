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
            BattleText.text = "";
            yield return BattleText.AddBattleText($"You encounter {Enemy.Name}!", 3.0f);

            foreach (var character in Party.Characters)
            {
                yield return character.PerformTurn(Party, Enemy, BattleText);
            }

            var enemyTarget = Party.Characters.First();
            yield return Enemy.PerformTurn(Party, enemyTarget, BattleText);

            yield return new WaitForSecondsRealtime(3);
        }
    }
}
