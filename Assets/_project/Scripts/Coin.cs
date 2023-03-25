using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Coin : MonoBehaviour
{
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
            //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector3Int gridPosition = tileMap.WorldToCell(mousePosition);

            //TileBase clickedTile = tileMap.GetTile(gridPosition);
           // tileMap.SetTile(gridPosition, baseTile);
           // print(clickedTile);
       // }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PagMan"))
        {
            Destroy(gameObject);
            GameManager.Instance.Score += 20;
        }
    }
}
