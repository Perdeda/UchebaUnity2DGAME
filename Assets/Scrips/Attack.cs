using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float timebtwAttack;
    public float atkSpeed;

    public Transform attackPos;
    public float attackRange;
    public LayerMask WhatIsEnemy;
    private int damage = 1;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timebtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.V))
            {
                anim.SetBool("IsAttackingR", true);
                anim.SetBool("IsWalkingR", true);
                anim.SetBool("IsWalkingR", true);
                timebtwAttack = atkSpeed;
                Collider2D[] damageEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, WhatIsEnemy);
                for (int i = 0; i < damageEnemies.Length; i++)
                {
                    damageEnemies[i].GetComponent<Behaviour>().TakeDamage(damage);
                }
            }
            else
            {
                anim.SetBool("IsAttackingR", false);
            }
        }
        else
        {
            timebtwAttack -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
