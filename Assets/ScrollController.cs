using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ScrollController : MonoBehaviour
{
    [SerializeField]private int _startSerialNo;

    private List<Button> _highScorePanelList;    
    private float[] _distanceArray;

    [SerializeField] private Button moveUp;
    [SerializeField] private Button moveDown;

    private int currentPanelNo;
    private Vector3 currentPanelPosition;
    private Vector3 topPanelPosition;
    private Vector3 bottomPanelPosition;

    [SerializeField] private GameObject currentPanel;
    [SerializeField] private GameObject topPanel;
    [SerializeField] private GameObject bottomPanel;
//    [SerializeField] private GameObject newPanel;


    #region Initialisation

    private void Start()
    {
        //Initialisation();

        currentPanelPosition = currentPanel.transform.position;
        topPanelPosition = topPanel.transform.position;
        bottomPanelPosition = bottomPanel.transform.position;


        //currentPanel.SetActive(true);
        //topPanel.SetActive(false);
        //bottomPanel.SetActive(false);
        //newPanel.SetActive(false);

        moveUp.onClick.AddListener(MoveUp);
        moveDown.onClick.AddListener(MoveDown);


    }

    private void Initialisation()
    {
        GameObject[] btn = GameObject.FindGameObjectsWithTag("button");

        //get all the panels
        foreach (GameObject gameObject in btn)
        {
            _highScorePanelList.Add(gameObject.GetComponent<Button>());
        }
    }

    
    #endregion

    private void MoveUp()
    {
        GameObject tempPanel = currentPanel;

        //current panel should go up
        currentPanel.transform.DOMove(topPanelPosition,2f,false);
        //bottom panel should move up 
        bottomPanel.transform.DOMove(currentPanelPosition, 2f, false);
        //topPanel now needs ti move to bottom panel position
        topPanel.transform.position = bottomPanelPosition;

        currentPanel = bottomPanel;
        bottomPanel = topPanel;
        topPanel = tempPanel;
    }

    private void MoveDown()
    {
        GameObject tempPanel = currentPanel;

        //current panel must go down
        currentPanel.transform.DOMove(bottomPanelPosition, 2f, false);
        //top five panel must come down
        topPanel.transform.DOMove(currentPanelPosition, 2f, false);
        //bottomPanel now needs to move to top panel position
        bottomPanel.transform.position = topPanelPosition;

        currentPanel = topPanel;
        topPanel = bottomPanel;
        bottomPanel = tempPanel;

    }






}
