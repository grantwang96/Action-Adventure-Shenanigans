using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

[System.Serializable]
/// <summary>
/// This is the save file that stores game info
/// </summary>
public class GameData {

    public static GameData current;

    public GameData() {

    }
}

[System.Serializable]
public class CharacterData {

    public string name;

    public int attack;
    public int defense;
    public int magicAttack;
    public int magicDefense;
    public int speed;
    public int charisma;
    
    public CharacterData() {
        this.name = "";
    }
}

[System.Serializable]
public class PlayerData : CharacterData{

    public PlayerData() : base() {

    }
}
