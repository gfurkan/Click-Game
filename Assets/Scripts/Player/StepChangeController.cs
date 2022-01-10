using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Step;

namespace Player
{
    public class StepChangeController : MonoBehaviour
    {
        #region Singleton

        private static StepChangeController _Instance=null;
        public static StepChangeController Instance
        {
            get
            {
                return _Instance;
            }
        }
        private void Awake()
        {
            if (_Instance == null)
            {
                _Instance = this;
            }
        }
        #endregion
        
        #region Fields

        [SerializeField] private ScriptInstances Scripts;
        [SerializeField] private Transform[] stepTransforms;
        
        private float stepMovementTime = 1;
        public enum Steps
        {
            board,dispenser,vase,trash,door
        }

        #endregion
        
        #region Public Methods

        public void ControlSteps(Steps step)
        {
            switch (step)
            {
                case Steps.board:
                    transform.DOMove(stepTransforms[(int) Steps.board].position, stepMovementTime).SetEase(Ease.OutBack);
                    transform.DORotate(stepTransforms[(int) Steps.board].eulerAngles, stepMovementTime);
                    break;
            
                case Steps.dispenser:
                    Scripts.glassDispenseStep.enabled = true;
                    transform.DOMove(stepTransforms[(int) Steps.dispenser].position, stepMovementTime).SetEase(Ease.OutBack);
                    transform.DORotate(stepTransforms[(int) Steps.dispenser].eulerAngles, stepMovementTime);
                    break;
            
                case Steps.vase:
                    Scripts.vaseStep.enabled = true;
                    transform.DOMove(stepTransforms[(int) Steps.vase].position, stepMovementTime).SetEase(Ease.OutBack);
                    transform.DORotate(stepTransforms[(int) Steps.vase].eulerAngles, stepMovementTime);
                    break;
            
                case Steps.trash:
                    Scripts.trashStep.enabled = true;
                    transform.DOMove(stepTransforms[(int) Steps.trash].position, stepMovementTime).SetEase(Ease.OutBack);
                    transform.DORotate(stepTransforms[(int) Steps.trash].eulerAngles, stepMovementTime);
                    break;
            
                case Steps.door:
                    Scripts.doorStep.enabled = true;
                    transform.DOMove(stepTransforms[(int) Steps.door].position, stepMovementTime*2);
                    transform.DORotate(stepTransforms[(int) Steps.door].eulerAngles, stepMovementTime*1.5f);
                    break;
            }
        }

        #endregion
    }

    #region Structs

    [System.Serializable]
    public struct ScriptInstances
    {
        [SerializeField] private GlassDispenseStep _glassDispenseStep;
        [SerializeField] private VaseStep _vaseStep;
        [SerializeField] private TrashStep _trashStep;
        [SerializeField] private DoorStep _doorStep;

        public GlassDispenseStep glassDispenseStep
        {
            get
            {
                return _glassDispenseStep;
            }
        }
        public VaseStep vaseStep
        {
            get
            {
                return _vaseStep;
            }
        }
        public TrashStep trashStep
        {
            get
            {
                return _trashStep;
            }
        }
        public DoorStep doorStep
        {
            get
            {
                return _doorStep;
            }
        }
    }


    #endregion

}
