using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Events
    public static event Action onGameReady;
    #endregion
    #region Variables
    private static GameManager _i;
    public static GameManager i { get { return _i; } }
    [SerializeField] private Transform sysMessagePoint;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameStats _stats;
    [SerializeField] private UIHandler _uiHandler;

    private GameObject sledGO;
    private StatSystem statSystem;
    private bool isPaused;


    #endregion
    
    #region Initialize
    private void Awake() 
    {
        _i = this;  
        Initialize();
    }

    private void Initialize() 
    {
        statSystem = new StatSystem(_stats);
        SpawnPlayerObject();
    }

    private void SpawnPlayerObject()
    {
        sledGO = Instantiate(GameAssets.i.pfSledObject, spawnPoint);
        sledGO.transform.parent = null;
        sledGO.GetComponent<IHandler>().Initialize();
        _uiHandler.Initialize();
        onGameReady?.Invoke();
    }

    #endregion

    public void PauseGame(){if(isPaused) return; else isPaused = true;}
    public void UnPauseGame(){if(isPaused) isPaused = false; else return;}
    
    public Transform GetSysMessagePoint(){ return sysMessagePoint;}
    public GameObject GetSledGO() { return sledGO; }
    public StatSystem GetStatSystem() { return statSystem; }
    public bool GetIsPaused() { return isPaused; }

}
