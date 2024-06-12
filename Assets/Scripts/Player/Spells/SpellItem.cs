using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ds
{
    public class SpellItem : Item
    {
        public GameObject spellWarmUp;
        public GameObject spellCastFx;
        public string spellAnimation;

        [Header("Spell Cost")]
        public int focusPointCost;

        [Header("Spell Type")]
        public bool isFaithSpell;
        public bool isMagicSpell;
        public bool isPyroSpell;

        [Header("Spell Description")]
        [TextArea]
        public string spellDescription;

        public virtual void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats)
        {
            Debug.Log("You attempt to cast a spell");
        }

        public virtual void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats)
        {
            Debug.Log("You successfully cast a spell");
            playerStats.DeductFocusPoints(focusPointCost);
        }
    }

}
