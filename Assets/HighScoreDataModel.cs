using UnityEngine;
using System.IO;

public class HighScoreDataModel : MonoBehaviour
{
    public class SaveObject{

        public HighScore[] highScoreData;
    };

    public struct HighScore
    {
        int sno;
        string name;
        int score;

        public HighScore(int sno, string name, int score)
        {
            this.sno = sno;
            this.name = name;
            this.score = score;
        }
    };

    public int StartFrom = 50;



    void Start()
    {
        string Save_Folder = Application.dataPath + "/SAVES";
        SaveObject saveObject = new SaveObject();

        //populate with 5 scores
        for (int i = 0; i < 100; i++)
        {
            HighScore entry = new HighScore(i,RandomNameGenerator(),i*Random.Range(100,1000));
            saveObject.highScoreData[i] = entry;
            Debug.Log("sd");
        }

        string json = JsonUtility.ToJson(saveObject);

        if (!Directory.Exists(Save_Folder))
        {
            Directory.CreateDirectory(Save_Folder);
        }

        File.WriteAllText(Save_Folder +  "/save.txt", json);

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

    };
