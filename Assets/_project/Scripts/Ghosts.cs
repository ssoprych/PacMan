using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghosts : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    public int Speed = 2;
    public LayerMask whatStopsMovement;
    public bool CanGoUp = true;
    public bool CanGoDown = false;
    public bool CanGoRight = true;

    public void Move()
    {
        if (CanGoUp == true)
        {
            if (!Physics2D.OverlapCircle(_rb.position, .8f, whatStopsMovement))
            {
                _rb.position += new Vector2(0f, 1f) * Speed *Time.deltaTime;
            }
            else
            {
                if (!Physics2D.OverlapCircle(_rb.position, .8f, whatStopsMovement))
                {
                    _rb.position += new Vector2(1f, 0f) * Speed * Time.deltaTime;
                };
            }
        }
        if (CanGoUp == false)
        {
            if (!Physics2D.OverlapCircle(_rb.position + new Vector2(0f, -1f), .001f, whatStopsMovement))
            { 
                _rb.position += new Vector2(0f, -1f) * Speed * Time.deltaTime;
            }
            else
            {
                CanGoUp = true;
            }
        }
    }
    private void Update()
    {
        Move();
    }


}
