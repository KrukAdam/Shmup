using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text lifeTMP;
    [SerializeField] private TMP_Text scoreTMP;
    [Space]
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TMP_Text bestScoreTMP;
    [SerializeField] private TMP_Text currentScoreTMP;
    [Space]
    [SerializeField] private TMP_Text timerTMP;

    private void Start()
    {
        GameManager.Instance.OnLifeChange += RefreshLifeBar;
        GameManager.Instance.OnScoreChange += RefreshScoreBar;
        GameManager.Instance.OnEndGame += EndScreen;
        GameManager.Instance.OnStartNewGame += TurnOffEndPanel;

        Setup();
    }

    private void Update()
    {
        timerTMP.text = GameManager.Instance.TimeRemaining.ToString("n2");
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLifeChange -= RefreshLifeBar;
        GameManager.Instance.OnScoreChange -= RefreshScoreBar;
        GameManager.Instance.OnEndGame -= EndScreen;
        GameManager.Instance.OnStartNewGame -= TurnOffEndPanel;
    }

    private void Setup()
    {
        currentScoreTMP.text = " ";
        bestScoreTMP.text = GameManager.Instance.BestScore.ToString();
    }

    private void RefreshLifeBar(int life)
    {
        lifeTMP.text = life.ToString();
    }

    private void RefreshScoreBar(int score)
    {
        scoreTMP.text = score.ToString();
    }

    private void EndScreen(int currenScore)
    {
        endPanel.SetActive(true);
        currentScoreTMP.text = currenScore.ToString();
        bestScoreTMP.text = GameManager.Instance.BestScore.ToString();
    }

    private void TurnOffEndPanel()
    {
        endPanel.SetActive(false);
    }
}
