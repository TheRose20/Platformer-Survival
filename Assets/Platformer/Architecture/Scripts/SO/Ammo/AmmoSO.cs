using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AmmoType", menuName = "Weapon/Create new AmmoType", order = 51)]
public class AmmoSO : ScriptableObject
{
    [SerializeField] private Sprite _sprite;

    [SerializeField] private GunType _ammoType;
    [SerializeField, Min(1)] private int _ammoAmount;

    //[SerializeField] private int _ammoAmountRandomMin;
    //[SerializeField] private int _ammoAmountRandomMax;


    public GunType AmmoType => _ammoType;
    public int AmmoAmount => _ammoAmount;
    //public int AmmoAmountRandomMin => _ammoAmountRandomMin;
    //public int AmmoAmountRangobMax => _ammoAmountRandomMax;
    public Sprite Sprite => _sprite;

}
