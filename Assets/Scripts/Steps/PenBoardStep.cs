using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Step
{
    public class PenBoardStep : StepContoller
    {
        #region Fields

        [SerializeField] private Material blackMaterial;
        
        private bool isPenChosed=false,isBboardChosed=false;
        
        #endregion

        #region Unity Methods

        private void OnDisable()
        {
            PlayerController.OnClickedEvent -= CompareObjectTags;
        }

        private void OnEnable()
        {
            PlayerController.OnClickedEvent += CompareObjectTags;
            ShowTutorial(0);
        }

        #endregion

        #region Private Methods

        void CompareObjectTags()
        {
            if (playerController.chosenObject.Equals("Pen"))
            {
                isPenChosed = true;
                HideTutorial(0);
                ShowTutorial(1);
            }

            if (isPenChosed)
            {
                if (playerController.chosenObject.Equals("Board"))
                {
                    isBboardChosed = true;
                    HideTutorial(1);
                }
            }

            if (isBboardChosed)
            {
                ChangeGlassMaterial();
            }
        }

        void ChangeGlassMaterial()
        {
            ChangeMaterial(transform.gameObject,blackMaterial);
            PlayParticle();
            StartCoroutine(ChangeStep());

            isPenChosed = false;
            isBboardChosed = false;
        }
        IEnumerator ChangeStep()
        {

            yield return new WaitForSeconds(1);
            stepChangeController.ControlSteps(StepChangeController.Steps.dispenser);
            DisableScript();
        }

        #endregion
    } 
}

