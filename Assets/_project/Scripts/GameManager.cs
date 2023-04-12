using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game")]
    public int Score;
    public bool ChaseMode;
    public int GhostEaten = 0;
    public GameObject Green, Blue, Red, Orange, Yellow, PacMan;
    public Transform RedSpawn, PacManSpawn, movePoint;
    public bool IsGreen, IsBlue, IsRed, IsOrange, IsYellow;
    public int PacHealth;
    public bool Death;

    [Header("Timer")]
    public float startTime = 0f;
    public float waitFor = 10f;
    public bool timerStart = false;
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
        PacHealth = 3;
        ChaseMode = false;
    }

    private void Update()
    {
        if (Death)
        {
            Death = false;
            PacMan.transform.position = new Vector2(PacManSpawn.position.x, PacManSpawn.position.y);
            movePoint.transform.position = new Vector2(PacManSpawn.position.x, PacManSpawn.position.y);
        }

        if (PacHealth == 0)
        {
            Time.timeScale = 0;
        }

        // Ending Chase after 10 seconds
        if (timerStart && Time.time - startTime > waitFor)
        {
            ChaseMode = false;
            timerStart = false;
        }

        // Ending Chase mode after eating 1 ghost 
        if (GhostEaten == 1)
        {
            GhostEaten = 0;
            ChaseMode = false;
        }

        // Respawning particular ghost 
        if (IsYellow)
        {
            Instantiate(Yellow, RedSpawn.transform.position, RedSpawn.transform.rotation);
            IsYellow = false;
        }
        if (IsOrange)
        {
            Instantiate(Orange, RedSpawn.transform.position, RedSpawn.transform.rotation);
            IsOrange = false;
        }
        if (IsRed)
        {
            Instantiate(Red, RedSpawn.transform.position, RedSpawn.transform.rotation);
            IsRed = false;
        }
        if (IsBlue)
        {
            Instantiate(Blue, RedSpawn.transform.position, RedSpawn.transform.rotation);
            IsBlue = false;
        }
        if (IsGreen)
        {
            Instantiate(Green, RedSpawn.transform.position, RedSpawn.transform.rotation);
            IsGreen = false;
        }

    }
}
