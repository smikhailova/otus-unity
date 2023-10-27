using System;
using UnityEngine;

[Serializable]
public class Weapon
{
	[SerializeField]
	private WeaponType _type;

    [SerializeField]
    private int _damage;

    public WeaponType Type => _type;
    public int Damage => _damage;
}
