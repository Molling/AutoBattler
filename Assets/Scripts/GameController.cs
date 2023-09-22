using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Window _factions;
    public Window _augments;
    public Window _missionStart;

    private MissionsController _missions;
    private DinosController _dinos;
    private CombatController _combat;

    private Faction _faction;

    private void Awake()
    {
        _factions.gameObject.SetActive(true);
        _augments.gameObject.SetActive(false);
        _missionStart.gameObject.SetActive(false);
    }

    private void Start()
    {
        _missions = GetComponent<MissionsController>();
        _dinos = GetComponent<DinosController>();
        _combat = FindObjectOfType<CombatController>();
    }

    public void FactionSelected(Faction faction)
    {
        _faction = faction;
        _factions.gameObject.SetActive(false);
        _missions.Init();
    }

    public void SelectDinos()
    {
        _dinos.Init();
    }

    public void SelectAugments()
    {
        _augments.gameObject.SetActive(true);
    }

    public void StartMission()
    {
        _augments.gameObject.SetActive(false);
        _missionStart.gameObject.SetActive(true);
    }

    public void MissionStarted()
    {
        _missionStart.gameObject.SetActive(false);
        _combat.Init();
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
