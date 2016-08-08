﻿using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveManager : MonoBehaviour {


    void Awake() {
        Util.saveManager = this;
    }

	// Use this for initialization
	void Start () {
	
	}

    public void load() {
        if (File.Exists(Application.persistentDataPath + "/gamedata.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamedata.dat", FileMode.Open);
            GameData data = null;
            try {
                data = (GameData)bf.Deserialize(file);
            }
            catch (Exception e) {
                Debug.LogError("Failed to load gamedata: " + e.Message);
            }
            file.Close();

            Util.wm.best = data.best;
            Util.wm.coins = data.coins;
            Util.wm.totalDistance = data.totalDistance;
            Util.wm.attempts = data.attempts;
        }

        if (File.Exists(Application.persistentDataPath + "/settings.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/settings.dat", FileMode.Open);
            Settings data = null;
            try {
                data = (Settings)bf.Deserialize(file);
            }
            catch (Exception e) {
                Debug.LogError("Failed to load settings: " + e.Message);
            }
            file.Close();

            Util.wm.musicMuted = data.musicMuted;
            Util.wm.soundMuted = data.soundMuted;
            Util.wm.scienceMode = data.scienceMode;
            Util.wm.controlScheme = data.controlScheme;
            ScrollManager.selector = data.selector;
            Util.wm.hasCheated = data.hasCheated;
            Util.wm.lastLaunched = data.lastLaunched;
        }

        if (File.Exists(Application.persistentDataPath + "/purchases.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/purchases.dat", FileMode.Open);
            Purchases data = null;
            try {
                data = (Purchases)bf.Deserialize(file);
            }
            catch (Exception e) {
                Debug.LogError("Failed to load purchases: " + e.Message);
            }
            file.Close();

            Util.rocketHolder.purchased = data.purchased;
        }
        Debug.Log("Data loaded");
    }

    public void save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamedata.dat");

        GameData data = new GameData();

        data.best = Util.wm.best;
        data.coins = Util.wm.coins;
        data.totalDistance = Util.wm.totalDistance;
        data.attempts = Util.wm.attempts;

        bf.Serialize(file, data);
        file.Close();


        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////


        bf = new BinaryFormatter();
        file = File.Create(Application.persistentDataPath + "/settings.dat");

        Settings data2 = new Settings();

        data2.musicMuted = Util.wm.musicMuted;
        data2.soundMuted = Util.wm.soundMuted;
        data2.scienceMode = Util.wm.scienceMode;
        data2.controlScheme = Util.wm.controlScheme;
        data2.selector = ScrollManager.selector;
        data2.hasCheated = Util.wm.hasCheated;
        data2.lastLaunched = Util.wm.lastLaunched;

        bf.Serialize(file, data2);
        file.Close();


        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////


        bf = new BinaryFormatter();
        file = File.Create(Application.persistentDataPath + "/purchases.dat");

        Purchases data3 = new Purchases();

        data3.purchased = Util.rocketHolder.purchased;

        bf.Serialize(file, data3);
        file.Close();

        Debug.Log("Saved all data successfully");
    }
}

[Serializable]
public class GameData {
    public float best;
    public int attempts;
    public int coins;
    public float totalDistance;
}

[Serializable]
public class Settings {
    public bool musicMuted;
    public bool soundMuted;
    public bool scienceMode;
    public ControlScheme controlScheme;
    public float selector;
    public bool hasCheated;
    public int lastLaunched;
}

[Serializable]
public class Purchases {
    public bool[] purchased;
}
