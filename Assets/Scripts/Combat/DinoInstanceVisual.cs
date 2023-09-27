using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class DinoInstanceVisual : MonoBehaviour
{
    public SpriteRenderer _dinoSprite;
    public SpriteRenderer _lane;
    public Slider _health;

    public DinoInstance _instance;
    private DinoInstanceVisual _opponent;
    private CombatController _controller;

    private Vector2 _laneSize = Vector2.one;

    private void Awake()
    {
        _controller = FindObjectOfType<CombatController>();
    }

    public void Init(DinoInstance dino, DinoInstanceVisual opponent)
    {
        _instance = dino;
        _opponent = opponent;
        Color c = _instance._dino._mainAttribute._color;
        _dinoSprite.color = c;
        c.a = 0.5f;
        _lane.color = c;
        _health.maxValue = _instance._health;
        SetUI();
    }

    public IEnumerator CombatUpdate()
    {
        _instance._charge += Time.deltaTime * _instance._dino._speed;

        SetUI();

        if (_instance._charge >= _controller._chargeMaxValue)
        {
            yield return new WaitForSeconds(0.2f);
            _instance._charge = 0;
            SetUI();
            _opponent.TakeDamage(GetDamage());
        }
        else
        {
            yield return null;
        }
    }

    public void TakeDamage(float damage)
    {
        _instance._health -= damage;
        if (_instance._health <= 0 )
        {
            _instance._charge = 0;
        }
        SetUI();
    }

    private void SetUI()
    {
        _health.value = _instance._health;
        _laneSize.x = _instance._charge / _controller._chargeMaxValue;
        _lane.size = _laneSize;
    }

    private float GetDamage()
    {
        float dmg = Random.Range(1, _instance._dino._power);
        if (_instance._dino._mainAttribute._bonusVS != null && _instance._dino._mainAttribute._bonusVS == _opponent._instance._dino._mainAttribute)
        {
            return dmg *= _controller._bonusMultiplier;
        }
        return dmg;
    }
}
