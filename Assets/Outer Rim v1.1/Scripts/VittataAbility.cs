using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OuterRimStudios
{
    public class VittataAbility : Ability
    {
        [Space, Header("Vittata Variables")]
        public ObjectPooling projectilePool;
        public Transform spawnPosition;
        public int clipSize;

        int clip;

        public override void ActivateAbility()
        {
            if (OnCooldown) return;

            GameObject _projectile = projectilePool.GetPooledObject();

            _projectile.transform.position = spawnPosition.position;
            _projectile.transform.rotation = spawnPosition.rotation;
            _projectile.SetActive(true);

            clip--;

            if (clip <= 0)
            {
                clip = clipSize;
                TriggerCooldown();
            }
        }
    }
}
