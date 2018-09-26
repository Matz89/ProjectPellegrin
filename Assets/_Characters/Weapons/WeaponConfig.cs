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
        [SerializeField] float attackCooldown = 1f;
        [SerializeField] float weaponDamage;

        public float GetTimeBetweenAttacks()
        {
            return attackCooldown;
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