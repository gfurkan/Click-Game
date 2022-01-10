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

        private void OnDisable()
        {
            PlayerController.OnClickedEvent -= CompareObjectTags;
        }

        private void OnEnable()
        {
            PlayerController.OnClickedEvent += CompareObjectTags;
            ShowGlassTutorial();
        }
        #endregion

        #region Private Methods
        private void CompareObjectTags()
        {
            if (!isGlassMoved)
            {
                if (playerController.chosenObject.Equals("Glass"))
                {
                    MoveGlass();
                    HideGlassTutorial();
                    ShowTutorial(0);
                }
            }
            if(isGlassMoved && !isGlassFilled)
            {
                if (playerController.chosenObject.Equals("Dispenser"))
                {
                    FillGlass();
                    HideTutorial(0);
                }
            }

            if (isGlassFilled && !isMaterialChanged)
            {
                StartCoroutine(ChangeStep());
            }
        }
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
            yield return new WaitForSeconds(0.5f);
            stepChangeController.ControlSteps(StepChangeController.Steps.vase);
            DisableScript();
        }
        
        #endregion
    }
}
