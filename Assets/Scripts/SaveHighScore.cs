using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveHighScore : MonoBehaviour
{
    public static SaveData saveData = new SaveData();
    public TMP_Text text;
    public static void SaveToJson(){
        if(UIHandler.Score > saveData.highScore){
            saveData.highScore = UIHandler.Score;
            string highScoreData = JsonUtility.ToJson(saveData);
            string filepath = Application.persistentDataPath + "/HighScoreData.json";
            Debug.Log(filepath);
            System.IO.File.WriteAllText(filepath, highScoreData);
        }
        
    }

    public void LoadFromJson(){
        string filepath = Application.persistentDataPath + "/HighScoreData.json";
        if(!System.IO.File.Exists(filepath))
        {
            saveData = new SaveData();
            return;
        }
        string highScoreData = System.IO.File.ReadAllText(filepath);
        saveData = JsonUtility.FromJson<SaveData>(highScoreData);
        text.text = "High Score:" + saveData.highScore;
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
            //SaveToJson();
        }
    }
}
[System.Serializable]
public class SaveData{
    public int highScore;
}