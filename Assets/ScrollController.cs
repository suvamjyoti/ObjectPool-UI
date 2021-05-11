using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScrollController : MonoBehaviour
{
    
    [SerializeField] private Button moveUp;
    [SerializeField] private Button moveDown;
    [SerializeField] private int _startSerialNo;

    [SerializeField] private RectTransform topPosition;
    [SerializeField] private RectTransform midPosition;
    [SerializeField] private RectTransform downPosition;

    private GameObject currentBlock;

    private static int _curentPanelStartIndex;
    public static int curentPanelStartIndex { get { return _curentPanelStartIndex; } }


    #region Initialisation

    private void Start()
    {
        //set panel values
        moveUp.onClick.AddListener(MoveUp);
        moveDown.onClick.AddListener(MoveDown);

        currentBlock = GenericObjectPool.Instance.spawner("Block", midPosition);
        currentBlock.SetActive(true);
        //currentBlock.transform.position = midPosition.position; 
    }

    #endregion

    #region ButtonAction

    private void MoveUp()
    {
        ButtonInteraction(false);

        currentBlock.transform.DOMove(topPosition.position, 0.2f);

        GameObject temp = GenericObjectPool.Instance.spawner("Block",downPosition);
        temp.transform.DOMove(midPosition.position, 0.5f);

        StartCoroutine(reset(temp));

    }

    private void MoveDown()
    {
        ButtonInteraction(false);

        currentBlock.transform.DOMove(downPosition.position, 0.2f);

        GameObject temp = GenericObjectPool.Instance.spawner("Block", topPosition);
        temp.transform.DOMove(midPosition.position, 0.5f);

        StartCoroutine(reset(temp));

    }

    #endregion

    #region HelperFunction

    IEnumerator reset(GameObject temp)
    {
        yield return new WaitForSeconds(0.3f);

        ButtonInteraction(true);

        currentBlock = temp;
    }

    private void ButtonInteraction(bool isInteractive)
    {
        moveUp.interactable = isInteractive;
        moveDown.interactable = isInteractive;
    }

    #endregion

}
