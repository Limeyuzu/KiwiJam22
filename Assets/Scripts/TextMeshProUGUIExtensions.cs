using TMPro;

namespace AdventureTogether
{
    public static class TextMeshProUGUIExtensions
    {
        public static void AddBattleText(this TextMeshProUGUI existingText, string textToAdd)
        {
            existingText.text += $"{textToAdd}\n";
        }
    }
}
