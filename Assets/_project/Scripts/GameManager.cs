using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score;
    public bool ChaseMode;
    public int GhostEaten = 0;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Score = 0;
        ChaseMode = false;
    }

    private void Update()
    {
        if (GhostEaten == 1)
        {
            GhostEaten = 0;
            ChaseMode = false;
        }

    }
}
