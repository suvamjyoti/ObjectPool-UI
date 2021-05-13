using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class panelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayName;
    [SerializeField] private TextMeshProUGUI serialNumber;
    [SerializeField] private TextMeshProUGUI highScore;

    private GameObject upPosition;
    private RectTransform downPosition;

    private void Awake()
    {
        upPosition = GameObject.FindGameObjectWithTag("upPosition");
        
    }

    public void setPanelValue(int sNo,string name,int score)
    {
        displayName.text = name;
        serialNumber.text = sNo.ToString();
        highScore.text = score.ToString();
    }

    //public void goUp()
    //{
    //    float dist = Vector3.Distance(upPosition.transform.position, transform.position);
    //    this.transform.DOMove(upPosition.transform.position, 0.001f * dist);
    //}

}
