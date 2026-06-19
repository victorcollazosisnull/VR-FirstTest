using TMPro;
using UnityEngine;

public class BasketScore : MonoBehaviour
{
    public int score;
    public int targetScore = 5;

    public TMP_Text scoreText;

    private void Start()
    {
        scoreText.text = $"Puntos: 0/{targetScore}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball"))
            return;

        score++;

        scoreText.text = $"Puntos: {score}/{targetScore}";

        if (score >= targetScore)
        {
            scoreText.text = "¡Ganaste!";
        }
    }
}