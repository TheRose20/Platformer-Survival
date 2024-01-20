using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
[RequireComponent(typeof(AmmoPickUpper))]
public class Ammo : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private AmmoSO _ammoStats;

    public int AmmoAmount => _ammoStats.AmmoAmount;
    public GunType AmmoType => _ammoStats.AmmoType;

    private void Initialization(AmmoSO ammoInfo)
    {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = ammoInfo.Sprite;
    }

    public void SetInitialization()
    {
        Initialization(_ammoStats);
    }

    private void OnEnable()
    {
        Initialization(_ammoStats);
    }

    private void OnValidate()
    {
        Initialization(_ammoStats);
    }
}
