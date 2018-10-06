using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OuterRimStudios
{
    public class Ability : MonoBehaviour
    {
        public string abilityName;
        [TextArea]
        public string abilityDescription;
        public int abilityDamage;
        public float abilityCooldown;
        public Stats stats;

        public enum AbilityInputType
        {
            OnPress,
            OnHold,
            OnRelease
        };

        public AbilityInputType abilityInputType;

        public bool OnCooldown { get; protected set; }


        protected virtual void Start() { }
        protected virtual void Update() { }
        public virtual void ActivateAbility() { }
        public virtual void DeActivateAbility() { }
        
        protected virtual void TriggerCooldown()
        {
            if (!OnCooldown)
                StartCoroutine(Cooldown());
        }

        protected virtual IEnumerator Cooldown()
        {
            OnCooldown = true;
            yield return new WaitForSeconds(abilityCooldown);
            OnCooldown = false;
        }
    }
}
