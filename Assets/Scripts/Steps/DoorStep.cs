using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Step
{
    public class DoorStep : MonoBehaviour,IPointerClickHandler
    {
        #region Fields

        [SerializeField] private ParticleSystem[] endGameParticles;
        private bool enableFinishingLevel = false;

        #endregion

        #region Unity Methods

        private void Start()
        {
            StartCoroutine(FadeImage());
        }
        
        #endregion

        #region Private Methods

        IEnumerator FadeImage()
        {
            yield return new WaitForSeconds(2);
            transform.GetComponent<CanvasGroup>().DOFade(1, 0.5f).OnComplete(() => enableFinishingLevel=true);
        
        }

        #endregion

        #region Public Methods

        public void OnPointerClick(PointerEventData eventData)
        {
            if (enableFinishingLevel)
            {
                for (int i = 0; i < endGameParticles.Length; i++)
                {
                    endGameParticles[i].Play();
                }
                Debug.Log("Level Finished");
            }
        }

        #endregion
    }
}
