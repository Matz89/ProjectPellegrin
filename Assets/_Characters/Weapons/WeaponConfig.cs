using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteMan3D.Templates;

namespace Pellegrin.Characters
{
    [CreateAssetMenu(menuName = ("Pellegrin/WeaponBasic"))]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] SpriteManagerState weaponSpriteState;
        [SerializeField] float timeBetweenSwings = 1f;
        [SerializeField] float weaponDamage;

        public float GetTimeBetweenAnimationCycles()
        {
            return timeBetweenSwings;
        }

        public SpriteManagerState GetWeaponSpriteState()
        {
            return weaponSpriteState;
        }

        public float GetWeaponDamage()
        {
            return weaponDamage;
        }
    }
}