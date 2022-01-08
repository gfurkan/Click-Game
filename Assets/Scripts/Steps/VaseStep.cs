using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player;
using UnityEngine;

public class VaseStep : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private Material glassWhiteMaterial;
    [SerializeField] private Transform glassVasePosition;
    private GameObject glass;
    private void Start()
    {
        playerController=PlayerController.Instance;
    }

    private void Update()
    {
        if (playerController.chosenObject.tag.Equals("Glass"))
        {
            glass = playerController.chosenObject;
            playerController.chosenObject.transform.DOMove(glassVasePosition.position, 0.5f);
        }

        if (playerController.chosenObject.tag.Equals("Vase"))
        {
            glass.GetComponent<MeshRenderer>().material = glassWhiteMaterial;
            playerController.step = PlayerController.Steps.trash;
            this.enabled = false;
        }
    }
}
