using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCoin : MonoBehaviour
{
    [SerializeField] private AudioClip _bigCoin;
    private void OnTriggerEnter2D(Collider2D collision)
    {

          if (collision.gameObject.CompareTag("PagMan"))
          {
            AudioManager.Instance.PlaySound2(_bigCoin);
            GameManager.Instance.ChaseMode = true;
            GameManager.Instance.GhostEaten = 0;
            GameManager.Instance.startTime = Time.time;
            GameManager.Instance.timerStart = true;
            Destroy(gameObject);


          }
    }
}
