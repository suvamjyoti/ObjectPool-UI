using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreDataModel : MonoBehaviour
{
    public struct HighScore
    {
        int sno;
        string name;
        int score;

        public HighScore(int sno,string name,int score)
        {
            this.sno = sno;
            this.name = name;
            this.score = score;
        }
    };

    List<HighScore> highScoreData;
    
    public int StartFrom = 50;

    void Start()
    {
        //populate with 5 scores
        for(int i = 0; i < 100; i++)
        {

            string name = RandomNameGenerator();
            //highScoreData.Add(new HighScore(i,name,i*Random.Range(1000,10000)));
            Debug.Log(name);
        }

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

}
