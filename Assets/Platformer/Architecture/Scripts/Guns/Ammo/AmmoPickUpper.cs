using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TarodevController;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoPickUpper : MonoBehaviour
{
    [SerializeField]private Ammo _ammo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out PlayerController player))
        {
            Gun[] components = collision.collider.GetComponentsInChildren<Gun>();
            int ammoAmount = _ammo.AmmoAmount;
            GunType ammoType = _ammo.AmmoType;
            for (int i = 0; i < components.Length; i++)
            {
                components[i].TryAddBullets(ammoType, ammoAmount);
            }
            gameObject.SetActive(false);
        }
    }

    private void OnValidate()
    {
        if (_ammo == null) _ammo = GetComponent<Ammo>();
    }

}
