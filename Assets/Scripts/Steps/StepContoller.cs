using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Player;
using UnityEngine.UI;
namespace Step
{
    public class StepContoller : MonoBehaviour
    {
        #region Fields

        [SerializeField] private ParticleSystem particle;
        [SerializeField] private CanvasGroup[] tutorials;
        private CanvasGroup glassTutorial;
        
        protected GameObject glassObject;
        protected PlayerController playerController;
        protected StepChangeController stepChangeController;
        
        private float showTutorialTime = 0.25f, hideTutorialTime = 0.25f;
        
        #endregion

        #region Unity Methods

        private void Awake()
        {
            playerController=PlayerController.Instance;
            stepChangeController=StepChangeController.Instance;
            
            glassObject = GameObject.FindGameObjectWithTag("Glass");
            glassTutorial = glassObject.transform.GetChild(0).transform.GetChild(0).GetComponent<CanvasGroup>();
        }

        #endregion
        
        #region Public Methods

        #region Tutorial Methods

        public void ShowGlassTutorial()
        {
            glassTutorial.DOFade(1, showTutorialTime);
        }
        public void HideGlassTutorial()
        {
            glassTutorial.DOFade(0, hideTutorialTime);
        }
        public void ShowTutorial(int tutorialIndex)
        {
            tutorials[tutorialIndex].DOFade(1, showTutorialTime);
        }
        public void HideTutorial(int tutorialIndex)
        {
            tutorials[tutorialIndex].DOFade(0, hideTutorialTime);
        }

        #endregion
        public virtual void MoveObject(Transform obj, Vector3 position)
        {
            obj.DOMove(position, 0.5f);
        }
        public void ChangeMaterial(GameObject obj,Material mat)
        {
            obj.GetComponent<MeshRenderer>().material = mat;
        }
        public void DisableScript()
        {
            playerController.chosenObject = " ";
            this.enabled = false;
        }
        public void PlayParticle()
        {
            particle.Play();
        }
        #endregion
    }
}

