using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour, IAttackHandler
{
 #region Variables
    [SerializeField] private Transform firePoint;
    #endregion

    #region Initialize
    public void Initialize()
    {
        Enemy.OnEnemyAttack += ThrowSnowball;
    }

    private void OnDisable() 
    {
        Enemy.OnEnemyAttack -= ThrowSnowball;
    }

    #endregion
    #region Handle Projectiles
    private void ThrowSnowball(GameObject _target)
    {
        Projectile newProjectile = ObjectPooler.DequeueObject<Projectile>("Snowball");
        newProjectile.transform.position = firePoint.position;
        newProjectile.transform.rotation = firePoint.rotation;
        newProjectile.gameObject.SetActive(true);
        newProjectile.gameObject.layer = LayerMask.NameToLayer("EnemyProjectile");
        newProjectile.Initialize(_target, GameManager.i.GetSnowballProjectileSO());
    }
    #endregion
}
