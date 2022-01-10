using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player;
using UnityEngine;

namespace Step
{
    public class TrashStep : StepContoller
    {
        #region Fields
        
        [SerializeField] private Transform glassTrashPosition;
        
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
        private void CompareObjectTags()
        {
            if (playerController.chosenObject.Equals("Trash"))
            {
                MoveObject(glassObject.transform,glassTrashPosition.position);
                HideTutorial(0);
            }
            
        }
        void GoToDoor()
        {
            StartCoroutine(ChangeStep());
        }

        private IEnumerator ChangeStep()
        {
            PlayParticle();
            
            yield return new WaitForSeconds(1);
            stepChangeController.ControlSteps(StepChangeController.Steps.door);
            DisableScript();
        }

        #endregion

        #region Public Methods

        public override void MoveObject(Transform obj, Vector3 position)
        {
            //base.MoveObject(obj, position);
            obj.DOMove(position, 0.5f).OnComplete(GoToDoor);
        }

        #endregion

    }
}
