using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagMan : MonoBehaviour
{
    public Rigidbody2D Rb;
    public Animator Anim;
    public float Speed = 3;

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical == 1)
        {
            Rb.velocity = Vector2.up * (Speed * Time.deltaTime * 1000);
            Anim.SetFloat("MoveX", 0);
            Anim.SetFloat("MoveY", 1);
        }
        if (vertical == -1)
        {
            Rb.velocity = Vector2.down * (Speed * Time.deltaTime * 1000);
            Anim.SetFloat("MoveX", 0);
            Anim.SetFloat("MoveY", -1);
        }
        if (horizontal == 1)
        {
            Rb.velocity = Vector2.right * (Speed * Time.deltaTime * 1000);
            Anim.SetFloat("MoveY", 0);
            Anim.SetFloat("MoveX", 1);
        }
        if (horizontal == -1)
        {
            Rb.velocity = Vector2.left * (Speed * Time.deltaTime * 1000);
            Anim.SetFloat("MoveY", 0);
            Anim.SetFloat("MoveX", -1);
        }
    }

    private void Update()
    {
        Move();
    }
}
