using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player;
using UnityEngine;

public class GlassDispenseStep : MonoBehaviour
{
    [SerializeField] private Transform glassDispensePosition;
    [SerializeField] private Material glassBlueMaterial;

    private PlayerController playerController;
    private GameObject glass;
    private bool isGlassMoved = false, isGlassFilled = false;
    private void Start()
    {
        playerController=PlayerController.Instance;
    }

    private void Update()
    {
        if (!isGlassMoved)
        {
            if (playerController.firstChosenObject.Equals("Glass"))
            {
                glass = GameObject.FindGameObjectWithTag("Glass");
                glass.transform.DOMove(glassDispensePosition.position, 0.5f);
                isGlassMoved = true;
            }
        }
        if(isGlassMoved && !isGlassFilled)
        {
            if (playerController.secondChosenObject.Equals("Dispenser"))
            {
                FillGlass();
            }
        }

        if (isGlassFilled)
        {
            playerController.step = PlayerController.Steps.vase;
            this.enabled = false;
        }
    }

    void FillGlass()
    {
        glass.GetComponent<MeshRenderer>().material = glassBlueMaterial;
        isGlassFilled = true;
    }
}
