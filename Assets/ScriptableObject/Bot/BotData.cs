using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bot", menuName = "ScriptableObject/BotData")]
public class BotData : ScriptableObject
{
    [Header("Bot")]
    public GameObject botModel;
    public Color botColor;
    public int botHealth;
    public float botSpeed;
    public int botValue;

    [Header("Gun")]
    public GameObject gunType;
    public Color gunColor;

    [Header("Bullet")]
    public GameObject bulletType;
    public int bulletDamage;
    public int bulletSpeed;
}
