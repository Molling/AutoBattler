using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDinoWindow : Window
{
    [System.Serializable]
    public struct DinoImage
    {
        public Image _image;
        public Dino _dino;
    }

    public DinoImage[] _dinos;
    public Button _button;
    private List<Dino> _selectedDinos = new List<Dino>();

    private void Start()
    {
        for (int i = 0; i < _dinos.Length; i++)
        {
            if (!_selectedDinos.Contains(_dinos[i]._dino))
            {
                Color c = _dinos[i]._dino._mainAttribute._color;
                c.r *= 0.5f;
                c.g *= 0.5f;
                c.b *= 0.5f;
                _dinos[i]._image.color = c;
            }
            else
            {
                _dinos[i]._image.color = _dinos[i]._dino._mainAttribute._color;
            }
        }
        _button.interactable = _selectedDinos.Count == 3;
    }

    public void Select(Dino dino)
    {
        if (_selectedDinos.Contains(dino))
        {
            _selectedDinos.Remove(dino);
        }
        else if (_selectedDinos.Count < 3)
        {
            _selectedDinos.Add(dino);
        }
        Start();
    }

    public void Confirm()
    {
        FindObjectOfType<DinosController>().Select(_selectedDinos.ToArray());
    }
}
