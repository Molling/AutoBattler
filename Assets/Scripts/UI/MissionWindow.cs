using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionWindow : Window
{
    [System.Serializable]
    public struct MissionImage
    {
        public Image _image;
        public Mission _mission;
    }

    public MissionImage[] _missions;
    private Mission _mission;

    public void Start()
    {
        int index = Random.Range(0, _missions.Length);
        _mission = _missions[index]._mission;

        for (int i = 0; i < _missions.Length; i++)
        {
            if (i != index)
            {
                Color c = _missions[i]._mission._mainAttribute._color;
                c.r *= 0.5f;
                c.g *= 0.5f;
                c.b *= 0.5f;
                _missions[i]._image.color = c;
            }
            else
            {
                _missions[i]._image.color = _missions[i]._mission._mainAttribute._color;
            }
        }
    }

    public void Confirm()
    {
        FindObjectOfType<MissionsController>().Confirm(_mission);
    }
}
