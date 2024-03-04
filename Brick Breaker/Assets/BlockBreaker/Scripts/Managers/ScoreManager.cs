using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    static int score;
    [SerializeField] int pointsPerBlockDestroyed = 1;

    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        scoreText.text = $"Score: {score}";
    }

    public void AddToScore()
    {
        score += pointsPerBlockDestroyed;
        scoreText.text = $"Score: {score}";
    }
}
