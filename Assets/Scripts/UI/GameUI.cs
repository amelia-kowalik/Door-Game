using System;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI timer;
    private bool _isTiming;
    private float _elapsedTime;
    
    void OnEnable()
    {
        GameManager.OnGameStart += StartTimer;
        GameManager.OnGameEnd += StopTimer;
    }

    void OnDisable()
    {
        GameManager.OnGameStart -= StartTimer;
        GameManager.OnGameEnd -= StopTimer;

    }

    private void Update()
    {
        if (_isTiming)
        {
            _elapsedTime += Time.deltaTime;
            timer.text = FormatTime(_elapsedTime);
        }
    }

    private void StartTimer()
    {
        _elapsedTime = 0;
        _isTiming = true;
    }

    private void StopTimer(float finalTime)
    {
        _isTiming = false;
        timer.text = FormatTime(finalTime);
    }
    
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 100) % 100);
        return $"{minutes:00}:{seconds:00}.{milliseconds:00}";
    }
}
