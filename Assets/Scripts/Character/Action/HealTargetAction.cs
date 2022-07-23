﻿using System.Collections;
using TMPro;
using UnityEngine;

namespace AdventureTogether
{
    public class HealTargetAction : BaseCharacterAction, ICharacterAction
    {
        [SerializeField] int HealAmount = 1;

        public override IEnumerator Act(Character thisChar, Party party, Character target, TextMeshProUGUI textOutput)
        {
            yield return(textOutput.AddBattleText($"{thisChar.Name} heals {target.Name}: "));
            target.ReceiveHealing(HealAmount, textOutput);
        }
    }
}
