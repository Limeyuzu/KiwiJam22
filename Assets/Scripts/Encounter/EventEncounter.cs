using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class EventEncounter : MonoBehaviour
    {
        [SerializeField] Party Party;
        [SerializeField] EventLocation EventLocation;
        [SerializeField] TextMeshProUGUI BattleText;

        IEnumerator Start()
        {
            BattleText.text = "";
            yield return BattleText.AddBattleText($"You encounter a {EventLocation.Name}, and take a short rest.", 3.0f);

            yield return EventLocation.Action.Act(EventLocation, Party, null, BattleText);

            yield return new WaitForSecondsRealtime(3);
        }
    }
}
