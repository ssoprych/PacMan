using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleports : MonoBehaviour
{
    public Transform movePoint;
    public Transform teleport;

    private void Update()
    {
        movePoint = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 position = collision.transform.position;
        position.x = this.teleport.position.x;
        position.y = this.teleport.position.y;
        collision.transform.position = position;
        if (collision.gameObject.CompareTag("PagMan"))
        {
            movePoint.transform.position = position;
        }
    }
}
