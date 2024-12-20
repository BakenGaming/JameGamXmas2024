using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerHandler : MonoBehaviour, IHandler
{
    #region Variables
    [SerializeField] private PlayerStatsSO playerStatsSO;
    [SerializeField] private bool canDie;

    private StatSystem _statSystem;
    private HealthSystem _healthSystem;

    #endregion
    #region Initialize
    public void Initialize()
    {
        SetupPlayer();
    }

    #endregion

    #region Get Functions
    public HealthSystem GetHealthSystem()
    {
        return _healthSystem;
    }

    public StatSystem GetStatSystem()
    {
        return _statSystem;
    }

    #endregion

    #region Handle Player Functions

    public void HandleDeath()
    {
        if(canDie) Destroy(gameObject);
        else Debug.Log("Hit");
    }

    public void UpdateHealth()
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region Player Setup
    private void SetupPlayer()
    {
        _statSystem = new StatSystem(playerStatsSO);
        _healthSystem = new HealthSystem(_statSystem.GetPlayerHealth());
        GetComponent<IInputHandler>().Initialize();
        GetComponent<IAttackHandler>().Initialize();
    }
    #endregion
}
