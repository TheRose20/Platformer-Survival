using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Create new PistolAsset", order = 51)]
public class PistolSO : ScriptableObject
{
    [SerializeField, Min(1)] private int _damage = 2;
    [SerializeField, Min(0)] private int _startAmmoAmount = 20;
    [SerializeField, Min(0.01f)] private float _cooldowm = 0.1f;

    public int Damage => _damage;
    public int StartAmmoAmount => _startAmmoAmount;
    public float Coooldowm => _cooldowm;
}
