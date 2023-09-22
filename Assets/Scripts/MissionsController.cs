using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsController : MonoBehaviour
{
    public MissionWindow _window;
    public Mission _mission;

    public DinoInstance[] _opponents;

    private void Awake()
    {
        _window.gameObject.SetActive(false);
    }

    internal void Init()
    {
        _window.gameObject.SetActive(true);
    }

    public void Confirm(Mission mission)
    {
        _mission = mission;

        _opponents = new DinoInstance[3];
        for (int i = 0; i < _opponents.Length; i++)
        {
            _opponents[i] = new DinoInstance(_mission._possibleDinos[Random.Range(0, _mission._possibleDinos.Length)]);
        }
        _window.gameObject.SetActive(false);
        GetComponent<GameController>().SelectDinos();
    }
}
