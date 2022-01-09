using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    public int health;
    public float speed = 1f;
    public Animator anim;
    public GameObject Blood;
    private float SpawningAnimationLength = 5.22f;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsSpawning", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        if(SpawningAnimationLength <= 0)
        {
            anim.SetBool("IsSpawning", false);
            anim.SetBool("IsMoving", true);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            SpawningAnimationLength -= Time.deltaTime;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
