using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadData : MonoBehaviour
{
    private static readonly string filePath = Application.persistentDataPath + "/scoreData.json";

    // Save the current score data to a JSON file
    public static void SaveScoreData()
    {
        string json = JsonUtility.ToJson(new ScoreDataWrapper(ScoreData.stageStars));
        File.WriteAllText(filePath, json);
        Debug.Log("Score data saved to: " + filePath);
    }

    // Load the score data from a JSON file
    public static void LoadScoreData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            ScoreDataWrapper data = JsonUtility.FromJson<ScoreDataWrapper>(json);
            ScoreData.stageStars = data.stageStars;
            Debug.Log("Score data loaded.");
        }
        else
        {
            Debug.Log("No score data file found.");
        }
    }

    // Helper class to wrap the stage stars array for JSON serialization
    [System.Serializable]
    private class ScoreDataWrapper
    {
        public int[] stageStars;

        public ScoreDataWrapper(int[] stageStars)
        {
            this.stageStars = stageStars;
        }
    }
}
