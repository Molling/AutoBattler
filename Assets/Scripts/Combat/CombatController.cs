using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public float _chargeMaxValue;
    public float _bonusMultiplier;
    public HUDWindow _hud;
    public EndWindow _victory;
    public EndWindow _defeat;
    public Lane[] _lanes;

    private void Awake()
    {
        _hud.gameObject.SetActive(false);
        _victory.gameObject.SetActive(false);
        _defeat.gameObject.SetActive(false);
        for (int i = 0; i < _lanes.Length; i++)
        {
            _lanes[i].gameObject.SetActive(false);
        }
    }

    internal void Init()
    {
        _hud.gameObject.SetActive(true);
        MissionsController mission = FindObjectOfType<MissionsController>();
        DinosController dinos = FindObjectOfType<DinosController>();
        for (int i = 0; i < _lanes.Length; i++)
        {
            _lanes[i].gameObject.SetActive(true);
            _lanes[i].Init(dinos._dinos[i], mission._opponents[i]);
        }
        StartCoroutine(CombatUpdate());
    }

    private IEnumerator CombatUpdate()
    {
        for (int i = 0; i < _lanes.Length; i++)
        {
            StartCoroutine(_lanes[i].CombatUpdate());
        }
        while (IsGameActive())
        {
            yield return null;
        }
        int playerWonLanes = 0;
        for (int i = 0; i < _lanes.Length; i++)
        {
            if (_lanes[i]._player._instance._health > 0)
            {
                playerWonLanes++;
            }
        }
        _hud.gameObject.SetActive(false);
        if (playerWonLanes >= 2)
        {
            _victory.gameObject.SetActive(true);
        }
        else
        {
            _defeat.gameObject.SetActive(true);
        }
    }

    private bool IsGameActive()
    {
        for (int i = 0; i < _lanes.Length; i++)
        {
            if (_lanes[i]._active)
            {
                return true;
            }
        }
        return false;
    }
}
