using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player;
using Step;
using UnityEngine;

namespace Step
{
    public class VaseStep : StepContoller
    {
        #region Fields

        [SerializeField] private Material glassWhiteMaterial;
        [SerializeField] private Transform glassVasePosition;

        private bool isGlassMoved = false,isVaseWatered=false;
        
        #endregion

        #region Unity Methods

        private void Update()
        {
            if (!isGlassMoved)
            {
                if (playerController.firstChosenObject.Equals("Glass"))
                {
                    MoveGlass();
                }
            }
            
            if (isGlassMoved && !isVaseWatered)
            {
                if (playerController.secondChosenObject.Equals("Vase"))
                {
                    StartCoroutine(WaterVase());
                }
            }

        }

        #endregion

        #region Private Methods

        void MoveGlass()
        {
            MoveObject(glassObject.transform,glassVasePosition.position);
            isGlassMoved = true;
        }

        IEnumerator WaterVase()
        {
            
            isVaseWatered = true;
            glassObject.transform.DORotate(new Vector3(0, 180, 50), 0.5f);
            yield return new WaitForSeconds(1);
            PlayParticle();
            yield return new WaitForSeconds(1);
            glassObject.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(ChangeStep());
        }

         IEnumerator ChangeStep()
        {
            ChangeMaterial(glassObject,glassWhiteMaterial);
            yield return new WaitForSeconds(1);
            playerController.step = PlayerController.Steps.trash;
            ChangeStringValues();
            this.enabled = false;
        }
        #endregion

        #region Public Methods

        public override void PlayParticle()
        {
            base.PlayParticle();
        }

        #endregion
    }
}

