using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Create new GunAsset", order = 51)]
public class GunSO : ScriptableObject
{
    [Header("Damage")]
    [SerializeField, Min(1)] private int _damage = 2;

    [Header("Start ammo")]
    [SerializeField, Min(0)] private int _startAmmoAmount = 20;

    [Header("Cooldown")]
    [SerializeField, Min(0.01f)] private float _cooldowm = 0.5f;

    public int Damage => _damage;
    public int StartAmmoAmount => _startAmmoAmount;
    public float Coooldowm => _cooldowm;
}
