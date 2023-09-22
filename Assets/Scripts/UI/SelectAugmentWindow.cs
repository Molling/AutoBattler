using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAugmentWindow : Window
{
    [System.Serializable]
    public struct DinoImage
    {
        public Image _image;
        public DinoInstance _dino;
    }

    public DinoImage[] _dinos;

    private void Start()
    {
        DinosController controller = FindObjectOfType<DinosController>();
        for (int i = 0; i < _dinos.Length; i++)
        {
            _dinos[i]._dino = controller._dinos[i];
            _dinos[i]._image.color = controller._dinos[i]._dino._mainAttribute._color;
        }
    }

    public void Go()
    {
        FindObjectOfType<GameController>().StartMission();
    }
}
