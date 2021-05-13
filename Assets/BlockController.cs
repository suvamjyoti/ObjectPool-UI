using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private panelView[] panelList;
    
    private void Awake()
    {
        panelList = GetComponentsInChildren<panelView>();
        
    }

    public void UpdatePanelData(int startIndex)
    {
        int i = startIndex;
        foreach(panelView panel in panelList)
        {
            HighScoreDataModel highScore = HighScoreData.instance.getHighscoreData(i);
            panel.setPanelValue(highScore.sno, highScore.name, highScore.score);
            i++;
        }

    }

}
