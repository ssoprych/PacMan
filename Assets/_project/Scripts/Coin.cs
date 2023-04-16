using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _coin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PagMan"))
        {
            AudioManager.Instance.PlaySound(_coin);
            Destroy(gameObject);
            GameManager.Instance.Score += 20;
        }
    }
}
