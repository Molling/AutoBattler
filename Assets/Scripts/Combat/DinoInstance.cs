using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DinoInstance
{
    public Dino _dino;

    public float _health;
    public float _charge;

    public DinoInstance(Dino dino)
    {
        _dino = dino;
        _health = _dino._defense;
        _charge = 0;
    }
}
