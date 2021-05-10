using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class panelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayName;
    [SerializeField] private TextMeshProUGUI serialNumber;
    [SerializeField] private TextMeshProUGUI highScore;

    public void setPanelValue(string sNo,string name,string score)
    {
        displayName.text = name;
        serialNumber.text = sNo;
        highScore.text = score;
    }

}
