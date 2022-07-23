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
        [SerializeField] float SecondsBetweenText = 1.0f;
        [SerializeField] TextMeshProUGUI BattleText;

        IEnumerator Start()
        {
            BattleText.text = "";
            BattleText.AddBattleText($"You encounter {Enemy.Name}!");

            yield return new WaitForSecondsRealtime(3);

            foreach (var character in Party.Characters)
            {
                character.PerformTurn(Party, Enemy, BattleText);
                yield return new WaitForSecondsRealtime(SecondsBetweenText);
            }

            var enemyTarget = Party.Characters.First();
            Enemy.PerformTurn(Party, enemyTarget, BattleText);
            yield return new WaitForSecondsRealtime(SecondsBetweenText);
        }
    }
}
