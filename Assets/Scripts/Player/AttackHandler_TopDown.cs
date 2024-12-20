using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler_TopDown : MonoBehaviour, IAttackHandler
{
    #region Variables
    [SerializeField] private Transform firePoint;
    #endregion

    #region Initialize
    public void Initialize()
    {
        PlayerInputController_TopDown.OnPlayerAttack += FireCookie;
        PlayerInputController_TopDown.OnPlayerThrowPresent += ThrowPresent;
    }

    private void OnDisable() 
    {
        PlayerInputController_TopDown.OnPlayerAttack -= FireCookie;    
        PlayerInputController_TopDown.OnPlayerThrowPresent -= ThrowPresent;
    }

    #endregion
    #region Handle Projectiles

    private void FireCookie(Vector3 _mousePos)
    {
        Projectile newProjectile = ObjectPooler.DequeueObject<Projectile>("Cookie");
        newProjectile.transform.position = firePoint.position;
        newProjectile.transform.rotation = firePoint.rotation;
        newProjectile.gameObject.SetActive(true);
        newProjectile.gameObject.layer = LayerMask.NameToLayer("PlayerProjectile");
        newProjectile.Initialize(_mousePos, GameManager.i.GetPlayerProjectileSO());
    }

    private void ThrowPresent(Vector3 _mousePos)
    {
        Projectile newProjectile = ObjectPooler.DequeueObject<Projectile>("Present");
        newProjectile.transform.position = firePoint.position;
        newProjectile.transform.rotation = firePoint.rotation;
        newProjectile.gameObject.SetActive(true);
        newProjectile.gameObject.layer = LayerMask.NameToLayer("PresentProjectile");
        newProjectile.Initialize(_mousePos, GameManager.i.GetPresentProjectileSO());
    }


    #endregion
}
