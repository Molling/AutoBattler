using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public DinoInstanceVisual _player;
    public DinoInstanceVisual _opponent;

    public bool _active => _player._instance._health > 0 && _opponent._instance._health > 0;

    internal void Init(DinoInstance player, DinoInstance opponent)
    {
        _player.Init(player, _opponent);
        _opponent.Init(opponent, _player);
    }

    public IEnumerator CombatUpdate()
    {
        while (_active)
        {
            yield return _player.CombatUpdate();
            yield return _opponent.CombatUpdate();
        }
    }
}
