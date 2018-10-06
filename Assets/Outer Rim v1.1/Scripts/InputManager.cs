using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OuterRimStudios
{
    public class InputManager : MonoBehaviour
    {
        public Ability ability;

        private void Update()
        {
            switch(ability.abilityInputType)
            {
                case Ability.AbilityInputType.OnPress:
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                        ability.ActivateAbility();
                    break;
                case Ability.AbilityInputType.OnHold:
                    if (Input.GetKey(KeyCode.Mouse0))
                        ability.ActivateAbility();
                    break;
                case Ability.AbilityInputType.OnRelease:
                    if (Input.GetKeyUp(KeyCode.Mouse0))
                    {
                        ability.ActivateAbility();
                        ability.DeActivateAbility();
                    }
                    break;
            }
        }
    }
}
