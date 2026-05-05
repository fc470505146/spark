using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //单例模式
    public static GameManager Instance { get; private set; }

    [SerializeField] private int levelNumber;
    [SerializeField] private List<GameLevel> gameLevelList;

    private int score;
    private float time;
    private bool isTimerActive;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Update()
    {
        if (isTimerActive)
        {
            time += Time.deltaTime;
        }
    }
    private void Start()
    {
        Lander.Instance.OnCoinPickup += Lander_OnCoinPickup;
        Lander.Instance.OnLanded += Lander_OnLanded;
        Lander.Instance.OnStateChanged += Lander_OnStateChanged;

        LoadCurrentLevel();
    }

    private void Lander_OnStateChanged(object sender, Lander.OnStateChangedEventArgs e)
    {
        isTimerActive = e.state == Lander.State.Normal;
    }

    private void Lander_OnLanded(object sender, Lander.OnLandedEventArgs e)
    {
        AddScore(e.score);
    }

    private void Lander_OnCoinPickup(object sender, EventArgs e)
    {
        AddScore(500);
    }
    public void AddScore(int addScoreAmount)
    {
        score += addScoreAmount;
        Debug.Log(score);
    }


    private void LoadCurrentLevel()
    {
        foreach (GameLevel gameLevel in gameLevelList)
        {
            if (gameLevel.GetLevelNumber() == levelNumber)
            {
                GameLevel spawnedGameLevel = Instantiate(gameLevel, Vector3.zero, Quaternion.identity);
                Lander.Instance.transform.position = spawnedGameLevel.GetLanderStartPosion();
            }
        }
    }





    public int GetScore()
    {
        return score;
    }

    public float GetTime()
    {
        return time;
    }

}
