using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public static event OnFireSnowball OnEnemyAttack;
    public delegate void OnFireSnowball(GameObject target);
    [SerializeField] private EnemyStatsSO enemyStatsSO;
    private bool enemyActive=false, dropLoot=true;
    private GameObject target;
    private float attackTimer=0;


    private void Initialize()
    {
        enemyActive = true;
        IAttackHandler handler = GetComponent<IAttackHandler>();
        handler.Initialize();
    }

    private void Update() 
    {
        if(enemyActive) FindTarget();
        UpdateTimers();    
    }

    private void UpdateTimers()
    {
        attackTimer -= Time.deltaTime;
    }


    private void FindTarget()
    {
        target = GameManager.i.GetPlayerGO();
        if(attackTimer <= 0) 
        {
            OnEnemyAttack?.Invoke(target);
            attackTimer = enemyStatsSO.timeBetweenShots;
        }
    }

    private void OnBecameVisible() 
    {
        Initialize();    
    }

    private void OnBecameInvisible() 
    {
        dropLoot=false;
        TakeDamage();   

    }

    public void TakeDamage()
    {
        if(dropLoot) GetComponent<LootBag>().DropLoot();
        Destroy(gameObject);
    }
}
