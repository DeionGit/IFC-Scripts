using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager 
{
    public static void SavePlayerScores(HighScoreTable scoreSys)
    {
        PlayerScores playerScore = new PlayerScores(scoreSys);
        string dataPath = Application.persistentDataPath + "/playerScore";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, playerScore);
        fileStream.Close();
    }

    public static PlayerScores LoadPlayerData()
    {
        string dataPath = Application.persistentDataPath + "/playerScore";
        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            PlayerScores playerScore = (PlayerScores) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
                return playerScore;
        }
        else
        {
            Debug.LogError("No se encontro ningun archivo de guardado");
            return null;
        }
    }
}
