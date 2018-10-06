using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OuterRimStudios
{
    [CreateAssetMenu(menuName = "OuterRimStudios/Stats")]
    public class Stats : ScriptableObject
    {
        public int damageLevel;
        public int defenseLevel;
        public int speedLevel;

        public int GetDamage(int originalDamage)
        {
            return originalDamage + damageLevel;
        }

        public int GetDefense(int originalDefense)
        {
            return originalDefense + defenseLevel;
        }

        public int GetSpeed(int originalSpeed)
        {
            return originalSpeed * speedLevel;
        }
    }
}
