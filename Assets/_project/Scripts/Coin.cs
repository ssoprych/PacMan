using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PagMan"))
        {
            GameManager.Instance.Score += 20;
            Destroy(gameObject);
        }
    }
}
