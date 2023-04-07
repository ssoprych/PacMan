using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.GhostEaten == 0 )
        {
            if (collision.gameObject.CompareTag("PagMan"))
            {
                GameManager.Instance.ChaseMode = true;
                Destroy(gameObject);
            }
        }
    }
}
