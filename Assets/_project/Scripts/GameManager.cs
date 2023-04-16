using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public TMP_Text ScoreText;

    [Header("Sounds")]
    [SerializeField] private AudioClip _winning;
    [SerializeField] private AudioClip _gameMusic;

    [Header("Panels")]
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private GameObject _winPanel;

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
        AudioManager.Instance.PlayMusic(_gameMusic);
        Time.timeScale = 1;
        Score = 0;
        PacHealth = 3;
        GhostEaten = 0;
        ChaseMode = false;
        _endPanel.SetActive(false);
        _winPanel.SetActive(false);
    }

    private void Update()
    {
        ScoreText.text = "SCORE: " + Score;
        if (Death)
        {
            movePoint.transform.position = new Vector2(PacManSpawn.position.x, PacManSpawn.position.y);
            PacMan.transform.position = new Vector2(PacManSpawn.position.x, PacManSpawn.position.y);
            Destroy(GameObject.FindGameObjectWithTag("YellowGhost"));
            Destroy(GameObject.FindGameObjectWithTag("RedGhost"));
            Destroy(GameObject.FindGameObjectWithTag("OrangeGhost"));
            Destroy(GameObject.FindGameObjectWithTag("BlueGhost"));
            Destroy(GameObject.FindGameObjectWithTag("GreenGhost"));
            IsBlue = true;
            IsGreen = true;
            IsRed = true;
            IsYellow = true;
            IsOrange = true;
            Death = false;
        }

        if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            
            _winPanel.SetActive(true);
            Time.timeScale = 0;
            //AudioManager.Instance.PlaySound(_winning); doesnt work:((
        }

        if (PacHealth <= 0)
        {
            if (Score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", Score);
            }
            _endPanel.SetActive(true);
            Time.timeScale = 0;
        }

        // Ending Chase after 10 seconds
        if (timerStart && Time.time - startTime > waitFor)
        {
            ChaseMode = false;
            timerStart = false;
        }

        // Ending Chase mode after eating 2 ghost 
        if (GhostEaten == 2)
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
