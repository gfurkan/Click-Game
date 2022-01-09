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
        private bool isValuesMatched = false;
        
        #endregion

        #region Unity Methods

        private void Update()
        {
            if (!isValuesMatched)
            {
                CompareObjects();
            }
            
        }

        #endregion

        #region Private Methods

        void CompareObjects()
        {
            if (playerController.firstChosenObject.Equals("Pen") && playerController.secondChosenObject.Equals("Board"))
            {
                StartCoroutine(ChageStep());
                isValuesMatched = true;
                
            }   
        }

        #endregion

        #region Private Methods

        IEnumerator ChageStep()
        {
            ChangeMaterial(transform.gameObject,blackMaterial);
            PlayParticle();
            yield return new WaitForSeconds(1);
            playerController.step = PlayerController.Steps.dispenser;
            ChangeStringValues();
            this.enabled = false;
        }

        #endregion
    } 
}

