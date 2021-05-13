using UnityEngine;
using System.IO;
using System.Collections;

public partial class HighScoreData : MonoBehaviour
{
    [System.Serializable]
    public class SaveObject{

        public HighScoreDataModel[] highScoreData = new HighScoreDataModel[100];

    };

    string Save_Folder;

    public SaveObject saveData;


    private static HighScoreData Instance;
    public static HighScoreData instance { get { return Instance; }}

    private void Awake()
    {
        if (Instance!=null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

        Save_Folder = Application.dataPath + "/SAVES";
        loadData();
    }

    private string RandomNameGenerator()
    {
        string characters = "abcdefghijklmnopqrstuvwxyz";
        string name = "";

        int k = Random.Range(3, 8);

        for (int i = 0; i < 10; i++)
        {

            if (i == k)
            {
                name += " ";
            }

            name += characters[Random.Range(0, characters.Length)];
        }

        return name;
    }

    private void loadData()
    {
        if(File.Exists(Save_Folder + "/save.txt"))
        {
            string SaveString = File.ReadAllText(Save_Folder + "/save.txt");
            saveData = JsonUtility.FromJson<SaveObject>(SaveString);
        }
        else
        {
            Debug.LogError("SaveData not found");
        }
    }

    public HighScoreDataModel getHighscoreData(int index)
    {
        return saveData.highScoreData[index];
    }

    };
