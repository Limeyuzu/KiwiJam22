using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] List<GameObject> PossibleEnemies;

        IEnumerator Start()
        {
            SpawnEnemy();

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
                var gameState = FindObjectOfType<GameState>();
                gameState.BattlesDefeated++;

                if (gameState.BattlesDefeated > 3)
                {
                    SceneLoader.LoadWinGameScene();
                } 
                else
                {
                    SceneLoader.LoadEventScene();
                }
            } 
            else if (Party.IsDefeated())
            {
                yield return BattleText.AddBattleText($"The party has fallen...", 3.0f);
                SceneLoader.LoadGameOverScene();
            }
        }

        private void SpawnEnemy()
        {
            var enemyLocation = GameObject.Find("EnemyLocation");
            var random = (int)Random.Range(0, PossibleEnemies.Count);
            var enemy = Instantiate(PossibleEnemies[random], new Vector3(0, 0, 0), Quaternion.identity);
            enemy.transform.position = enemyLocation.transform.position;
            Enemy = enemy.GetComponent<Character>();
        }
    }
}
