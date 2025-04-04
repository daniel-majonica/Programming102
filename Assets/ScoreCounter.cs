using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public float CurrentScore = 0;
    public TMP_Text ScoreDisplay;

    private void Start()
    {
        ScoreDisplay.text = CurrentScore.ToString();
    }
    public void ChangeScore(float value)
    {
        CurrentScore += value;
        ScoreDisplay.text = CurrentScore.ToString();
    }
}
