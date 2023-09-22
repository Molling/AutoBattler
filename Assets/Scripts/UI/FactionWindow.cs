using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactionWindow : Window
{
    public Button _confirm;

    private Faction _faction;

    public void Select(Faction faction)
    {
        _faction = faction;
        _confirm.interactable = true;
    }

    public void Confirm()
    {
        FindObjectOfType<GameController>().FactionSelected(_faction);
    }
}
