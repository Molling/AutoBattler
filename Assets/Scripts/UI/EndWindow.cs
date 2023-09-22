using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndWindow : Window
{
    public void Go()
    {
        FindObjectOfType<GameController>().Reload();
    }
}
