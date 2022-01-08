using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player;
using UnityEngine;

public class TrashStep : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private Transform glassTrashPosition,glass;
    private void Start()
    {
        playerController=PlayerController.Instance;
    }

    private void Update()
    {
        if (playerController.chosenObject.tag.Equals("Trash"))
        {
            glass.DOMove(glassTrashPosition.position, 0.5f).OnComplete(GoToDoor);
        }
    }

    void GoToDoor()
    {
        playerController.step = PlayerController.Steps.door;
        this.enabled = false;
    }
}
