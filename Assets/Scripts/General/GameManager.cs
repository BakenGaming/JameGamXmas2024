using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

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
    [SerializeField] private ProjectileSO[] availableProjectiles;
    [SerializeField] private Transform projectileHolder;
    [SerializeField] private float constantSpeed;
    
    private GameObject playerGO;
    private bool isPaused;

    #endregion
    
    #region Initialize
    private void Awake() 
    {
        _i = this;  
        SetupObjectPools();  
        Initialize();
    }

    private void Initialize() 
    {
        SpawnPlayerObject();
    }

    private void SpawnPlayerObject()
    {
        playerGO = Instantiate(GameAssets.i.pfPlayerObject, spawnPoint);
        playerGO.transform.parent = null;
        playerGO.GetComponent<IHandler>().Initialize();
        onGameReady?.Invoke();
    }

    public void SetupObjectPools()
    {
        ObjectPooler.SetupPool(GameAssets.i.pfProjectileBase.GetComponent<Projectile>(), 2, "Cookie");
        ObjectPooler.SetupPool(GameAssets.i.pfProjectileBase.GetComponent<Projectile>(), 2, "Present");
        ObjectPooler.SetupPool(GameAssets.i.pfProjectileBase.GetComponent<Projectile>(), 2, "Snowball");
        
        //The below is placed in location where object is needed from pool
        //==============================
        //PREFAB_SCRIPT instance = ObjectPooler.DequeueObject<PREFAB_SCRIPT>("NAME");
        //instance.gameobject.SetActive(true);
        //instance.Initialize();
        //==============================
    }
    #endregion
    public void PauseGame(){if(isPaused) return; else isPaused = true;}
    public void UnPauseGame(){if(isPaused) isPaused = false; else return;}
    public ProjectileSO GetPlayerProjectileSO(){return availableProjectiles[0];}
    public ProjectileSO GetPresentProjectileSO(){return availableProjectiles[1];}
    public ProjectileSO GetSnowballProjectileSO(){return availableProjectiles[2];}
    public Transform GetProjectilePoolHolder(){return projectileHolder;}
    public float GetConstantSpeed(){return constantSpeed;}
    public float GetInitialBoost(){return playerGO.GetComponent<IHandler>().GetStatSystem().GetBoostAmount();}    
    public int GetInitialCookieCount(){return playerGO.GetComponent<IHandler>().GetStatSystem().GetCookieMax();}    
    public int GetInitialPresentCount(){return playerGO.GetComponent<IHandler>().GetStatSystem().GetPresentMax();}    
    public Transform GetSysMessagePoint(){ return sysMessagePoint;}
    public GameObject GetPlayerGO() { return playerGO; }
    public bool GetIsPaused() { return isPaused; }

}
