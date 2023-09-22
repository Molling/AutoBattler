using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosController : MonoBehaviour
{
    public SelectDinoWindow _window;

    public DinoInstance[] _dinos;

    private void Awake()
    {
        _window.gameObject.SetActive(false);
    }

    internal void Init()
    {
        _window.gameObject.SetActive(true);
    }

    public void Select(Dino[] dinos)
    {
        _dinos = new DinoInstance[3];
        for (int i = 0; i < dinos.Length; i++)
        {
            _dinos[i] = new DinoInstance(dinos[i]);
        }
        _window.gameObject.SetActive(false);
        GetComponent<GameController>().SelectAugments();
    }
}
