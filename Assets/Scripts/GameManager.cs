using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class GameManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] Fish fish;
    [SerializeField] GameObject main;
    [SerializeField] GameObject pipes;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject socreObject;
    [SerializeField] Text scoreText;
    [SerializeField] Text mainText;
    [SerializeField] Text startText;
    [SerializeField] Text bestScore;
    [SerializeField] Text currentScoreText;
    [SerializeField] Button adsButton;
    
#if UNITY_ANDROID
    string gameId = "3382678";
#endif

    string myPlacementId = "rewardedVideo";
    string placementId = "Banner";
    string serverId;


    int score;

    enum State
    {
        READY, PLAY, GAMEOVER
    }
    State state;

    private void Start()
    {
        adsButton.interactable = Advertisement.IsReady(myPlacementId);
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
        StartCoroutine(ShowBannerWhenReady());

        serverId = PlayerPrefs.GetString("id");

        if(serverId == "")
        {
            Network.Instance.GetServerID();
        }

        Load();
        state = State.READY;
        gameOver.SetActive(false);
        pipes.SetActive(false);
        socreObject.SetActive(false);
        fish.SetKinematic(true);
    }

    IEnumerator ShowBannerWhenReady()
    {
        while(!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }


    public void ShowRewardedViedeo()
    {
        Advertisement.Show(myPlacementId);
    }


    void Update()
    {
        switch (state)
        {
            case State.READY:
                if (Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                    
                }
                break;
            case State.PLAY:
                if (fish.IsDead)
                {
                    if (score > PlayerPrefs.GetInt(Constant.kScore))
                    {
                        Save();
                    }                    
                    Load();
                    GameOver();                    
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
        main.SetActive(false);
        startText.gameObject.SetActive(false);
        mainText.gameObject.SetActive(false);
        socreObject.SetActive(true);
    }

    void GameOver()
    {
        state = State.GAMEOVER;
        gameOver.SetActive(true);
        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();

        foreach (ScrollObject scrollObject in scrollObjects)
        {
            scrollObject.enabled = false;
        }

    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "현재 점수 : " + score.ToString();
        currentScoreText.text = "현재 점수 : " + score.ToString();
        if(score == 0)
        {
            currentScoreText.text = "현재 점수 : 0";
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt(Constant.kScore, score);
    }

    public void Load()
    {
        bestScore.text = "최고 점수 : " + PlayerPrefs.GetInt(Constant.kScore).ToString();
        mainText.text = "최고 점수 : " + PlayerPrefs.GetInt(Constant.kScore).ToString();
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacementId)
        {
            adsButton.interactable = true;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // 이어하기
    }
}