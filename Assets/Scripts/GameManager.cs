using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Fish fish;
    [SerializeField] GameObject pipes;
    [SerializeField] GameObject main;
    [SerializeField] GameObject socreObject;
    [SerializeField] Text startText;
    [SerializeField] GameObject gameOver;

    int score;

    enum State
    {
        READY, PLAY, GAMEOVER
    }
    State state;

    private void Start()
    {
        gameOver.SetActive(false);
        pipes.SetActive(false);
        socreObject.SetActive(false);
        state = State.READY;
        fish.SetKinematic(true);
    }


    void Update()
    {
        switch (state)
        {
            case State.READY:
                if (Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                    main.SetActive(false);
                    startText.gameObject.SetActive(false);
                    socreObject.SetActive(true);
                }
                break;
            case State.PLAY:
                if (fish.IsDead)
                {
                    GameOver();
                    gameOver.SetActive(true);
                }
                break;
            case State.GAMEOVER:
                                                                 
                break;
        }
    }

    void GameStart()
    {
        state = State.PLAY;

        fish.SetKinematic(false);
        pipes.SetActive(true);
    }

    void GameOver()
    {
        state = State.GAMEOVER;

        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();

        foreach (ScrollObject scrollObject in scrollObjects)
        {
            scrollObject.enabled = false;
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}