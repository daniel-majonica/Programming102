using TMPro;
using UnityEngine;

public class RunningTimer : MonoBehaviour
{
    public TriggerZone StartPlatform;
    public TriggerZone EndPlatform;
    public TMP_Text TimerDisplay;
    public ScoreCounter ScoreCounter;
    public float Length = 15;
    private float CurrentLength = 0;
    private bool timerRunning = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimerDisplay.text = "not started";
        StartPlatform.OnTriggerEnterEvent += _ => StartTimer();
        EndPlatform.OnTriggerEnterEvent += _ => StopTimer(true);
        CurrentLength = Length;
    }
    private void Update()
    {
        if (timerRunning)
        {
            CurrentLength -= Time.deltaTime;
            TimerDisplay.text = Mathf.Round(CurrentLength).ToString();
            if (CurrentLength < 0)
            {
                StopTimer(false);

            }
        }
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer(bool success)
    {
        if (!timerRunning)
            return;

        timerRunning = false;
        if (success)
        {
            ScoreCounter.ChangeScore(Mathf.Round(CurrentLength));
        }
        else
        {
            ScoreCounter.ChangeScore(-1);
        }
        CurrentLength = Length;
        TimerDisplay.text = "stopped Timer";
    }
}
