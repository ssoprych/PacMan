using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghosts : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    public int Speed = 2;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public bool CanGoUp = true;
    public bool CanGoDown = false;
    public bool CanGoRight = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
    }

    public void Move()
    {
        _rb.position = Vector3.MoveTowards(_rb.position, movePoint.position, Speed * Time.deltaTime);

             if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .1f, whatStopsMovement))
                movePoint.position += new Vector3(0f, 1f, 0f);

             if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, whatStopsMovement))
                movePoint.position += new Vector3(0f, -1f, 0f);

             if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .1f, whatStopsMovement))
                movePoint.position += new Vector3(1f, 0f, 0f);
             if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, whatStopsMovement))
                movePoint.position += new Vector3(-1f, 0f, 0f);
            
    }
    private void Update()
    {
        Move();
    }


}
