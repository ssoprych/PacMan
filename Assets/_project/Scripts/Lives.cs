using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public int numOfPacs;

    public Image[] Pacs;
    public Sprite PacMan;
    public Sprite Man;

    private void Update()
    {
        for (int i = 0; i< Pacs.Length; i++)
        {
            if (GameManager.Instance.PacHealth > numOfPacs)
            {
                GameManager.Instance.PacHealth = numOfPacs;
            }
            if (i < GameManager.Instance.PacHealth)
            {
                Pacs[i].sprite = PacMan;
            }
            else
            {
                Pacs[i].enabled = false;
            }

            
        }
    }
}
