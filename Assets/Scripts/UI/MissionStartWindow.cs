using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionStartWindow : Window
{
    public void Go()
    {
        FindObjectOfType<GameController>().MissionStarted();
    }
}
