using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/// <summary>
/// Manager that handles saving, deleting, and loading saves
/// </summary>
public static class SaveManager {

    public static List<GameData> savedGames = new List<GameData>();

    // adds a new saved game to the saves list
    public static void SaveGame() {
        savedGames.Add(GameData.current);
        PersistSavedGames();
    }

    // overwrites a particular saved game in the saves list
    public static void SaveGame(int index) {
        if(index < 0 || index > savedGames.Count) { return; }
        savedGames[index] = GameData.current;
        PersistSavedGames();
    }

    // deletes a saved game from the list and persists the change to file
    public static void DeleteSavedGame(int index) {
        if (index < 0 || index > savedGames.Count) { return; }
        savedGames.RemoveAt(index);
        PersistSavedGames();
    }

    // writes the saved games list to file
    private static void PersistSavedGames() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, savedGames);
        file.Close();
    }

    // populates the savedGames list with data from  savedGames.gd
    public static void LoadGamesList() {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            savedGames = (List<GameData>)bf.Deserialize(file);
            file.Close();
        }
    }
}
