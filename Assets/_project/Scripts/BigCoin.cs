using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PagMan"))
        {
            GameManager.Instance.ChaseMode = true;
            Destroy(gameObject);
        }
    }
}
