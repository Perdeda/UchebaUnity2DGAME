using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform attackPos;
    public float attackRange;
    public LayerMask WhatIsEnemy;
    private int damage = 1;

    private float timebtwAttack;
    public float invTime = 2f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] damageEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, WhatIsEnemy);
        for (int i = 0; i < damageEnemies.Length; i++)
        {
            damageEnemies[i].GetComponent<HODITGULYAT>().TakeDamageWolf(damage, invTime);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
