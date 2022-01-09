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
        private bool isObjectMoved = false;
        #endregion

        #region Unity Methods

        private void Update()
        {
            if (!isObjectMoved)
            {
                if (playerController.firstChosenObject.Equals("Trash") || playerController.secondChosenObject.Equals("Trash"))
                {
                    MoveObject(glassObject.transform,glassTrashPosition.position);
                    isObjectMoved = true;
                }
            }
        }

        #endregion

        #region Private Methods

        void GoToDoor()
        {
            StartCoroutine(ChangeStep());
        }

        private IEnumerator ChangeStep()
        {
            PlayParticle();
            yield return new WaitForSeconds(1);
            playerController.step = PlayerController.Steps.door;
            ChangeStringValues();
            this.enabled = false;
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
