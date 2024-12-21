using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Projectile : MonoBehaviour
{
    #region Initialize
    private Rigidbody2D projectileRB;
    private SpriteRenderer projectileSR;
    private GameObject target;
    private ProjectileSO projectileSO;
    private float lifeTimer;
    private Vector3 shootDir;
    private ProjectileType _type;
    public void Initialize(GameObject _target, ProjectileSO _projectileSO)
    {
        _type = _projectileSO.projectileType;
        target = _target;
        projectileSO = _projectileSO;
        projectileSR = GetComponent<SpriteRenderer>();
        projectileSR.sprite = projectileSO.projectileSprite[UnityEngine.Random.Range(0,projectileSO.projectileSprite.Length)];
        projectileRB = GetComponent<Rigidbody2D>();
        lifeTimer = _projectileSO.lifeTime;

        shootDir = (target.transform.position - transform.position).normalized;
        transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(shootDir) - 90f);
    }

    public void Initialize(Vector3 _shootDir, ProjectileSO _projectileSO)
    {
        _type = _projectileSO.projectileType;
        projectileSO = _projectileSO;
        projectileSR = GetComponent<SpriteRenderer>();
        projectileSR.sprite = projectileSO.projectileSprite[UnityEngine.Random.Range(0,projectileSO.projectileSprite.Length)];
        projectileRB = GetComponent<Rigidbody2D>();
        lifeTimer = _projectileSO.lifeTime;

        shootDir = _shootDir;
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle - 90f);
    }

    #endregion
    #region Loop
    void Update()
    {
        if (GameManager.i.GetIsPaused()) return;

        UpdateTimers();
        transform.position += shootDir * projectileSO.projectileSpeed * Time.deltaTime;
        
        
        if(lifeTimer <= 0) DestroyProjectile();
    }

    private void UpdateTimers()
    {
        lifeTimer -= Time.deltaTime;
    }

    private void DestroyProjectile()
    {
        ObjectPooler.EnqueueObject(this, projectileSO.projectileName);
    }

    #endregion
    #region Collision
    private void OnTriggerEnter2D(Collider2D _trigger) 
    {
        IDamageable damageable = _trigger.gameObject.GetComponent<IDamageable>();

        if(damageable != null && _type == ProjectileType.cookie) 
            damageable.TakeDamage();

        IHandler handler = _trigger.gameObject.GetComponent<IHandler>();

        if(handler != null && _type == ProjectileType.snowball) 
            handler.HandleDeath();

        House house = _trigger.gameObject.GetComponent<House>();

        if(house != null && _type == ProjectileType.present)
            house.DeliverPresent();

        ObjectPooler.EnqueueObject(this, projectileSO.projectileName);
    }
    #endregion
}
