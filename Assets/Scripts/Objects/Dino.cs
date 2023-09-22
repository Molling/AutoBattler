using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dino : ScriptableObject
{
    public Attribute _mainAttribute;

    [Range(1, 10)] public float _power;
    [Range(10, 30)] public float _defense;
    [Range(1, 3)] public float _speed;
}
