using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagMan : MonoBehaviour
{
    public Rigidbody2D Rb;
    public Animator Anim;
    public Transform movePoint;
    public float Speed = 3f;
    public LayerMask whatStopsMovement;

    private void Start()
    {
        movePoint.parent = null;
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

    }

    public void Move()
    {
        Rb.position = Vector3.MoveTowards(Rb.position, movePoint.position, Speed * Time.deltaTime);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (Vector3.Distance(Rb.position, movePoint.position) <= .01f)
        {
            if (vertical == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .1f, whatStopsMovement))
                    movePoint.position += new Vector3(0f, 1f, 0f);
                Anim.SetFloat("MoveX", 0);
                Anim.SetFloat("MoveY", 1);
            }
            else if (vertical == -1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, whatStopsMovement))
                    movePoint.position += new Vector3(0f, -1f, 0f);
                Anim.SetFloat("MoveX", 0);
                Anim.SetFloat("MoveY", -1);
            }
            else if (horizontal == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .1f, whatStopsMovement))
                    movePoint.position += new Vector3(1f, 0f, 0f);
                Anim.SetFloat("MoveY", 0);
                Anim.SetFloat("MoveX", 1);
            }
            else if (horizontal == -1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, whatStopsMovement))
                    movePoint.position += new Vector3(-1f, 0f, 0f);
                Anim.SetFloat("MoveY", 0);
                Anim.SetFloat("MoveX", -1);
            }
        }
    }

    private void Update()
    {
        Move();
    }
}
