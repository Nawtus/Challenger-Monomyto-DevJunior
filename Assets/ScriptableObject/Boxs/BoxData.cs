using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Box", menuName = "ScriptableObject/BoxData")]
public class BoxData : ScriptableObject
{
    [Header("BoxVariables")]
    public Sprite boxType;
    public int boxHealth;
    public Color boxColor;
    public GameObject rewardType;
    public int scoreValue;
}
