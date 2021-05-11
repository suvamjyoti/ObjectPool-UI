using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;




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

    public void setPanelValue(string sNo,string name,string score)
    {
        displayName.text = name;
        serialNumber.text = sNo;
        highScore.text = score;
    }

    //public void goUp()
    //{
    //    float dist = Vector3.Distance(upPosition.transform.position, transform.position);
    //    this.transform.DOMove(upPosition.transform.position, 0.001f * dist);
    //}

}
