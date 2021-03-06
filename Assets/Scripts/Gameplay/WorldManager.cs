﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class WorldManager : MonoBehaviour {
    public GameObject rocket;
    public Text coinCounter;
    public GameObject plusIcon;
    public Text bestScore;
    public GameObject bestBar;
    public float gameTime = 0;
    public GameObject gm;
    public bool gameActive = false;
    public bool dieScreen = false;
    public float cameraSizePlay;
    public float cameraSizeMenu;
    public Vector3 cameraMenuPosition;
    public RectTransform coinIcon;

    public string zoneID;


    public float best;
    public int coins;
    public float totalDistance;
    public int attempts = 0;
    public float adWatchTimeCoins = 0;
    public float adWatchTimeLife = 0;
    public int gamesSinceAdWatch = 6;
    public DateTime collectTime;

    public int controlsChanged = 5;
    bool firstGame = true;

    public bool musicMuted = false;
    public bool soundMuted = false;
    public bool scienceMode = false;
    public ControlScheme controlScheme = 0;
    public bool hasCheated = false;
    public bool godmode = false;
    public int lastLaunched = 1;

    public GameObject settingsPrefab;
    GameObject settings;

    public GameObject IAPPrefab;
    GameObject IAP;

    public GameObject secondChancePrefab;
    GameObject secondChance;

    public GameObject dailyRewardPrefab;
    GameObject dailyRewardPanel;

    public GameObject coinCanvasPrefab;

    public GameObject controlTextPrefab;

    public bool alternate = true;

    void Awake() {
        Util.wm = this;
        Util.coin = GameObject.Find("Coin").GetComponent<RectTransform>();
        Util.canvas = GameObject.Find("Canvas");
        cameraSizePlay = 10f * ((Screen.height * 1f / Screen.width) / 1.7777f);
        cameraSizeMenu = 8.5f;
        cameraMenuPosition = new Vector3(0, -1f, -10f);

        zoneID = "rewardedVideo";
    }
    // Use this for initialization
    void Start () {
        Application.targetFrameRate = 50;

        
        gameTime = 0;
        Util.cm.cameraTargetSize = cameraSizeMenu;
        Camera.main.transform.position = cameraMenuPosition;
        Util.rocketHolder.crayonColor = CrayonColor.one;
        collectTime = new DateTime();
        Util.saveManager.load();
        updateCoinCount();
        updateBest();
        Util.audioManager.setMute();
        //Util.scrollManager.spawnShowcase();
        Util.scrollManager.setRocket();
        //Util.rocket.transform.position = new Vector3(0, -100f, 0);
        Util.width = Camera.main.GetComponent<BoxCollider2D>().size.x / 2f;
        Util.even10 = true;

        //Advertisement.Initialize();

        checkDailyReward(); 

        InvokeRepeating("toggleEven", 0.25f, 0.25f);
        InvokeRepeating("everySecond", 1f, 1f);

    }
	
	// Update is called once per frame
	void Update () {
        if (gameActive) {
            gameTime += Time.deltaTime;
        }

        Util.even = !Util.even;
        if (Util.even) {
            Util.even2 = !Util.even2;
            /*if (Util.even2) {
                Util.even3 = !Util.even3;
            }*/
        }
	}

    void checkDailyReward() {
        DateTime dt = UnbiasedTime.Instance.Now();
        if (dt != null) {
            double timeElapsed = dt.Subtract(collectTime).TotalSeconds;
            if (timeElapsed > 79200f) {
                //spawn collection panel :)
                dailyRewardPanel = Instantiate(dailyRewardPrefab);
            }
        }
    }

    public void collectDailyReward() {
        collectTime = UnbiasedTime.Instance.Now();
        coins += Util.dailyReward;
        WorldManager.updateCoinCount();
        Util.saveManager.save();
        spawnCoinPile();
    }

    void toggleEven() {
        Util.even10 = !Util.even10;
        alternate = !alternate;
    }

    void everySecond() {
        adWatchTimeCoins--;
        adWatchTimeLife--;

        if (adWatchTimeCoins < 0) {
            adWatchTimeCoins = 0;
        }

        if (gameActive) {
            Util.achievementManager.checkAchievementsDistance();
        }
    }

    public void play() {
        if (!gameActive) {
            if (Util.rocketHolder.purchased[ScrollManager.selectedRocket] || ScrollManager.selectedRocket == 0 || godmode) {
                if (secondChance != null) secondChance.GetComponent<SecondChance>().close();
                gamesSinceAdWatch++;
                attempts++;
                //if (best > 25f) Util.wm.bestBar.transform.position = new Vector3(0, Util.wm.best / GameManager.scoreSpeed * GameManager.rocketSpeed - 5f, 0);
                lastLaunched = ScrollManager.selectedRocket;
                Util.gm.play();
                Destroy(Util.scrollManager.colorSwitcher);
                if (attempts <= 1) Util.achievementManager.firstLaunch();
                if (settings != null) settings.GetComponent<SettingsManager>().close();
                if (IAP != null) IAP.GetComponent<IAP>().close();
                if (dailyRewardPanel != null) dailyRewardPanel.GetComponent<DailyReward>().close();

                if (attempts < 10 || firstGame || controlsChanged > 0) {
                    GameObject obj = Instantiate(controlTextPrefab);
                    obj.transform.SetParent(Util.canvas.transform);
                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 100f);
                    obj.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                    if (controlScheme == ControlScheme.tilt || controlScheme == ControlScheme.tilt2 || controlScheme == ControlScheme.tiltInvert) {
                        obj.GetComponent<Text>().text = "TILT";
                    }
                    else {
                        obj.GetComponent<Text>().text = "TOUCH";
                    }
                }
                firstGame = false;
                controlsChanged--;
            }
            else {
                CancelInvoke("play");
                ScrollManager.selector = lastLaunched;
                Util.scrollManager.setClosestRocket();
                Invoke("play", 0.75f);
            }
        }
    }

    public void showSettings() {
        if (settings == null) {
            settings = Instantiate(settingsPrefab);
            if (IAP != null) IAP.GetComponent<IAP>().close();
            if (secondChance != null) secondChance.GetComponent<SecondChance>().close();
        }
        else {
            settings.GetComponent<SettingsManager>().close();
        }
    }

    public void showLeaderboards() {
        Social.ShowLeaderboardUI();
    }

    public void showIAP() {
        Debug.Log("Showing IAP");
        if (!gameActive) {
            if (IAP == null) {
                IAP = Instantiate(IAPPrefab);
                if (settings != null) settings.GetComponent<SettingsManager>().close();
                if (secondChance != null) secondChance.GetComponent<SecondChance>().close();
            }
            else {
                IAP.GetComponent<IAP>().close();
            }
        }
    }

    public void showSecondChance() {
        secondChance = Instantiate(secondChancePrefab);
        if (IAP != null) IAP.GetComponent<IAP>().close();
        if (settings != null) settings.GetComponent<SettingsManager>().close();
    }


    public void leftArrow() {
        ScrollManager.selector--;
        Util.scrollManager.setClosestRocket();
        ScrollManager.selector = ScrollManager.selectedRocket;
        Util.scrollManager.moveBG();
        Util.audioManager.playSelectorClick();
    }

    public void rightArrow() {
        ScrollManager.selector++;
        Util.scrollManager.setClosestRocket();
        ScrollManager.selector = ScrollManager.selectedRocket;
        Util.scrollManager.moveBG();
        Util.audioManager.playSelectorClick();
    }

    public static void updateCoinCount() {
        Util.wm.coinCounter.text = "" + Util.wm.coins;
        int length = Util.wm.coinCounter.text.Length;
        Util.wm.plusIcon.GetComponent<RectTransform>().localPosition = new Vector3(-136f - (length - 1) * 46f, 0, 0);
    }

    public static void updateBest() {
        Util.wm.bestScore.text = "" + (int)Util.wm.best;
    }

    public void toggleGodmode() {
        if (true || Application.platform == RuntimePlatform.WindowsEditor) {
            godmode = !godmode;
            hasCheated = true;
            Util.saveManager.save();
        }
    }

    public void freeMoney() {
        if (godmode || Application.platform == RuntimePlatform.WindowsEditor) {
            coins += 500;
            WorldManager.updateCoinCount();
        }
    }

    public void buy() {
        if (!gameActive && !dieScreen && !Util.scrollManager.ri.purchased) {
            if (coins >= Util.scrollManager.ri.cost) {
                coins -= Util.scrollManager.ri.cost;
                Util.rocketHolder.purchased[ScrollManager.selectedRocket] = true;
                Util.saveManager.save();
                WorldManager.updateCoinCount();
                Util.achievementManager.buyRocketAchievement();
                Util.audioManager.playKaching();
            }
            else {

            }
        }
    }

    public void spawnCoinPile(int amount) {
        for (int i = 0; i < amount; i++) {
            Invoke("spawnSingleCoin", 1f / amount * i);
        }
    }
    public void spawnCoinPile() {
        spawnCoinPile(30);
    }
    void spawnSingleCoin() {
        GameObject obj = Instantiate(coinCanvasPrefab);
        obj.GetComponent<CoinCanvas>().randomize(new Vector2(540f, 1100f), 600f, 1000f);
    }

    void OnApplicationQuit() {
        Util.saveManager.save();
    }
}
