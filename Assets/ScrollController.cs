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

    private static int _curentPanelIndex;

    #region Initialisation

    private void Start()
    {
        //set panel values
        moveUp.onClick.AddListener(MoveUp);
        moveDown.onClick.AddListener(MoveDown);

        _curentPanelIndex = _startSerialNo;

        //currentBlock = GenericObjectPool.Instance.spawner("Block", midPosition);

        if (_curentPanelIndex < 92)
        {
            ButtonInteraction(false);

            currentBlock = GenericObjectPool.Instance.spawner("Block", midPosition);

            UpdateData(currentBlock.GetComponent<BlockController>(), _curentPanelIndex, true);

            currentBlock.transform.DOMove(midPosition.position, 0.5f);

            StartCoroutine(reset(currentBlock));
        }
        else
        {
            Debug.Log(" entered _startSerialNo is too high ");
        }

    }

    #endregion

    #region ButtonAction

    private void MoveUp()
    {
        if (_curentPanelIndex < 92)
        {
            ButtonInteraction(false);

            currentBlock.transform.DOMove(topPosition.position, 0.2f);

            GameObject temp = GenericObjectPool.Instance.spawner("Block", downPosition);

            UpdateData(temp.GetComponent<BlockController>(),_curentPanelIndex, true);

            temp.transform.DOMove(midPosition.position, 0.5f);

            StartCoroutine(reset(temp));
        }
    }

    private void MoveDown()
    {
        if (_curentPanelIndex > 8)
        {
            ButtonInteraction(false);

            currentBlock.transform.DOMove(downPosition.position, 0.2f);

            GameObject temp = GenericObjectPool.Instance.spawner("Block", topPosition);

            UpdateData(temp.GetComponent<BlockController>(),_curentPanelIndex-8, false);

            temp.transform.DOMove(midPosition.position, 0.5f);

            StartCoroutine(reset(temp));
        }
    }

    #endregion

    #region HelperFunction

    IEnumerator reset(GameObject temp)
    {
        yield return new WaitForSeconds(0.3f);

        ButtonInteraction(true);

        currentBlock = temp;
    }

    private void UpdateData(BlockController block,int i,bool isGoingUp)
    {
        if (isGoingUp)
        {
            block.UpdatePanelData(i);
            _curentPanelIndex += 8;
        }
        else
        {
            block.UpdatePanelData(i-8);
            _curentPanelIndex = i-8;
        }
    }

    private void ButtonInteraction(bool isInteractive)
    {
        moveUp.interactable = isInteractive;
        moveDown.interactable = isInteractive;
    }

    #endregion

}
