using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "ScriptableObject/GunData")]
public class GunData : ScriptableObject
{
    [Header("GunVariables")]
    public GameObject gunType;
    public Color gunColor;
    public int bullets;

    [Header("BulletVariables")]
    public GameObject bulletType;
    public int bulletDamage;
    public float bulletSpeed;
}
