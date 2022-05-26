using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController Instance;

    public static int Points { get; private set; }
    public static int HighestPoints { get; private set; }
    public static bool GameStarted { get; private set; }

    [SerializeField] private TextMeshProUGUI gameResult;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI highestPointsText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        gameResult.text = "";

        GameStarted = true;

        Field.Instance.GenerateField();

        HighestPoints = PlayerPrefs.GetInt("point");

        highestPointsText.text = HighestPoints.ToString();
    }

    public void Win()
    {
        GameStarted = false;
        gameResult.text = "You Win!";
    }

    public void Lose()
    {
        GameStarted = false;
        gameResult.text = "You Lose!";
    }

    public void AddPoints(int points)
    {
        SetPoints(Points + points);
    }

    private void SetPoints(int points)
    {
        Points = points;
        pointsText.text = Points.ToString();
        HighestScore();
    }

    private void HighestScore()
    {
        if (Points > HighestPoints)
        {
            PlayerPrefs.SetInt("point", Points);
        }
    }

    public void ExitOnClick()
    {
        SceneManager.LoadScene(0);
    }

}
