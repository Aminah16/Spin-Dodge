using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TMP_Text highScoreDisplay;

    void Start()
    {
        // Retrieve the high score from PlayerPrefs
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Update the high score display
        UpdateHighScoreDisplay(highScore);
    }

    // Method to update the high score display
    public void UpdateHighScoreDisplay(int highScore)
    {
        highScoreDisplay.text = "High Score: " + highScore;
    }
}