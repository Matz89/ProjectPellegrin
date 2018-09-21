using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteMan3D;
using SpriteMan3D.Templates;

namespace Pellegrin.Characters
{


    public class CanEquipWeapon : MonoBehaviour
    {

        [SerializeField] int orderInLayer;  //TODO find way to remove this
        [SerializeField] WeaponConfig weaponConfig;
        //[SerializeField] 

        // Use this for initialization
        void Start()
        {

            //Find the sprite manager (find where root is None, if more than one then assert?)
            SpriteManager rootSpriteManager = GetComponentInChildren<SpriteManager>(); //TODO safe to assume its always first object in heirarchy is the root sprite manager?

            //Create WeaponSpriteState
            GameObject weapon = new GameObject("Weapon");

            //give sprite renderer and sprite manager components to it
            //TODO remove orderInLayer and find own orderInLayer (if we eliminate other children?)
            SpriteRenderer weaponSpriteRenderer = weapon.AddComponent<SpriteRenderer>();
            weaponSpriteRenderer.sortingOrder = orderInLayer;

            SpriteManager weaponSpriteManager = weapon.AddComponent<SpriteManager>();
            weaponSpriteManager.rootManager = rootSpriteManager;

            //Load weapon's Spritestate
            weaponSpriteManager.CopyFrom(weaponConfig.GetWeaponSpriteState());

            //Attach to rootSpriteManager's game object
            weapon.transform.SetParent(rootSpriteManager.transform);

            //TODO find better way to remove these, simply resets the transforms component values to defaults (0,0,0 0,0,0 1,1,1)
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
            weapon.transform.localScale = Vector3.one;

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}