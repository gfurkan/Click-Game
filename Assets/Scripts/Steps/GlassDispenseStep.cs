using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player;
using UnityEngine;

namespace Step
{
    public class GlassDispenseStep : StepContoller
    {
        #region Fields

        [SerializeField] private Transform glassDispensePosition;
        [SerializeField] private Material glassBlueMaterial;

        private bool isGlassMoved = false, isGlassFilled = false, isMaterialChanged = false;

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
            if(isGlassMoved && !isGlassFilled)
            {
                if (playerController.secondChosenObject.Equals("Dispenser"))
                {
                    FillGlass();
                }
            }

            if (isGlassFilled && !isMaterialChanged)
            {
               StartCoroutine(ChangeStep());
            }
        }
        #endregion

        #region Private Methods
        void MoveGlass()
        {
            MoveObject(glassObject.transform,glassDispensePosition.position);
            isGlassMoved = true;
        }
        void FillGlass()
        {
            ChangeMaterial(glassObject,glassBlueMaterial);
            isGlassFilled = true;
        }

        IEnumerator ChangeStep()
        {
            PlayParticle();
            isMaterialChanged = true;
            yield return new WaitForSeconds(1);
            playerController.step = PlayerController.Steps.vase;
            ChangeStringValues();
            this.enabled = false;
        }
        #endregion
    }
}
