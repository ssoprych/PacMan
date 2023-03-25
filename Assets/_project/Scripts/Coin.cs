using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Coin : MonoBehaviour
{
    public Tilemap tileMap;
    public TileBase baseTile;
    private Vector3Int position;
    private Vector3Int positionTile;
    private int _positionX;
    private int _positionY;

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
            Vector2 playerPosition = Camera.main.ScreenToWorldPoint(collision.gameObject.transform.position);
            Vector3Int gridPosition = tileMap.WorldToCell(playerPosition);
            tileMap.SetTile(gridPosition, baseTile);
            GameManager.Instance.Score += 20;
        }
    }
}
