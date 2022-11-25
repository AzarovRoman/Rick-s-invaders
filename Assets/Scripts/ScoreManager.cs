using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    int score = 0;

    public void AddPoint()
    {
        score += 10;
        scoreText.text = $"{score} points";
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = $"{score} points";
    }
}