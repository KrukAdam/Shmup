using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<int> OnLifeChange = delegate { }; //int = currentLife
    public event Action<int> OnScoreChange = delegate { };     //int = score
    public event Action<int> OnEndGame = delegate { };      //int = score
    public event Action OnStartNewGame = delegate { };

    public int BestScore => PlayerPrefs.GetInt(Consts.BestScoreKey);
    public float TimeRemaining { get; private set; }

    [field: SerializeField] public float TimeSingleGame { get; private set; }

    private int _score = 0;
    private bool _inGame = false;


    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Time.timeScale = 0; //pause the game on start
    }

    void Update()
    {
        if (_inGame)
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining -= Time.deltaTime;
            }
            else
            {
                EndGame();
            }

            return;
        }

        if (Input.anyKey)
        {
            StartNewGame();
        }
    }

    public void RefreshLife(int currentLife)
    {
        OnLifeChange(currentLife);

        if(currentLife <= 0)
        {
            EndGame();
        }
    }

    public void AddScore()
    {
        _score++;
        OnScoreChange(_score);
    }

    private void EndGame()
    {
        _inGame = false;

        if(_score > BestScore) SaveBestScore(_score);

        OnEndGame(_score);

        Time.timeScale = 0;
    }

    private void StartNewGame()
    {
        TimeRemaining = TimeSingleGame;

        _inGame = true;

        Time.timeScale = 1;

        _score = 0;
        OnScoreChange(_score);

        OnStartNewGame();
    }

    private void SaveBestScore(int score)
    {
        PlayerPrefs.SetInt(Consts.BestScoreKey, score);
    }
}
