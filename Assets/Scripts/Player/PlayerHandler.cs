using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour, IHandler
{
    #region Events
    public static event Action onLaunched;
    #endregion
    #region Variables
    private float extraForce;
    private Rigidbody2D sledRB;
    #endregion
    #region Initialize
    public void Initialize()
    {
        UIHandler.OnLaunchSled += Launch;
        SetupPlayer();
    }

    #endregion

    #region Get Functions

    #endregion

    #region Handle Player Functions
    private void Launch(int _count)
    {
        Debug.Log("Launch");
        extraForce = (float)_count;
        Vector2 _newForce = new Vector2(GameManager.i.GetStatSystem().GetBaseMoveSpeed() + extraForce*5f, 0f);
        sledRB.AddForce(_newForce, ForceMode2D.Impulse);
        onLaunched?.Invoke();
    }

    public void SlowMomentum()
    {
        sledRB.drag = 3f;
    }

    #endregion

    #region Player Setup
    private void SetupPlayer()
    {
        sledRB = GetComponent<Rigidbody2D>();
    }
    #endregion
}
