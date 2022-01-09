using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HODITGULYAT : MonoBehaviour
{
    public float speed = 20f;
    public int HP = 5;
    private Rigidbody2D rb;
    public bool isgrounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.01f;
    public LayerMask whatIsGround;
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (!isgrounded)
            return;
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");// движение в [-1,1]
        if (moveX == 0)
        {
            anim.SetBool("IsWalkingR", false);
            anim.SetBool("IsWalkingL", false);
        }
        if (moveX > 0)
        {
            anim.SetBool("IsWalkingR", true);
            anim.SetBool("IsWalkingL", false);
        }
        if (moveX < 0)
        {
            anim.SetBool("IsWalkingR", false);
            anim.SetBool("IsWalkingL", true);
        }
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
        // прыжок
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rb.AddForce(Vector2.up * 500);
            rb.AddForce(Vector2.up * 500);
            rb.AddForce(Vector2.up * 500);
        }

    }
    public void TakeDamageWolf(int damage, float invTime)
    {

        HP -= damage;
        FindObjectOfType<GameManager>().End();
        Destroy(gameObject);
    }
}
