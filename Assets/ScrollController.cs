using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ScrollController : MonoBehaviour
{
    [SerializeField] private int _startSerialNo;

    private panelView[] _highScorePanelList;
    
    //private float[] _distanceArray;
    //private float _panelGap;

    [SerializeField] private Button moveUp;
    [SerializeField] private Button moveDown;


    #region Initialisation

    private void Start()
    {
        Initialisation();
        
        //set panel values


        moveUp.onClick.AddListener(MoveUp);
        moveDown.onClick.AddListener(MoveDown);

    }

    private void Initialisation()
    {
        panelView[] _highScorePanelList = transform.GetComponentsInChildren<panelView>();

        Debug.Log(_highScorePanelList.Length);

        //for (int j = 0; j < _highScorePanelList.Length; j++)
        //{
        //    RectTransform rectTransform = _highScorePanelList[i].GetComponent<RectTransform>();
        //    rectTransform.position = new Vector3(rectTransform.position.x, _distanceArray[i],rectTransform.position.z);
        //}

    }


    #endregion

    private void MoveUp()
    {
       
    }

    private void MoveDown()
    {
      
    }






}
