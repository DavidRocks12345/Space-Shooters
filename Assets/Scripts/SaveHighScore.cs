using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHighScore : MonoBehaviour
{
    public SaveData saveData = new SaveData();

    public void SaveToJson(){
        saveData.highScore = UIHandler.Score;
        string highScoreData = JsonUtility.ToJson(saveData);
        string filepath = Application.persistentDataPath + "/HighScoreData.json";
        Debug.Log(filepath);
        System.IO.File.WriteAllText(filepath, highScoreData);
    }

    public void LoadFromJson(){
        string filepath = Application.persistentDataPath + "/HighScoreData.json";
        string highScoreData = System.IO.File.ReadAllText(filepath);
        saveData = JsonUtility.FromJson<SaveData>(highScoreData);
        Debug.Log(saveData.highScore);
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadFromJson();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            SaveToJson();
        }
    }
}
[System.Serializable]
public class SaveData{
    public int highScore;
}