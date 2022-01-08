using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace PenBoard
{
    public class PenBoardStep : MonoBehaviour
    {
        private PlayerController playerController;
        [SerializeField] private Material blackMaterial;
        private void Start()
        {
            playerController=PlayerController.Instance;
        }

        private void Update()
        {
            if (playerController.compareObject)
            {
                if (playerController.firstChosenObject.Equals("Pen") && playerController.secondChosenObject.Equals("Board"))
                {
                    transform.GetComponent<MeshRenderer>().material = blackMaterial;
                }  
            }
        }
    } 
}

