using System.Collections;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public static class TextMeshProUGUIExtensions
    {
        public static IEnumerator AddBattleText(this TextMeshProUGUI existingText, string textToAdd, float secondsToWait = 1.0f)
        {
            existingText.text += $"{textToAdd}\n";
            yield return new WaitForSecondsRealtime(secondsToWait);
        }
    }
}
