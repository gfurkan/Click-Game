using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Step
{
    public class DoorStep : MonoBehaviour,IPointerClickHandler
    {
        #region Fields

        [SerializeField] private ParticleSystem[] endGameParticles;
        [SerializeField] private Button replayButton;
        [SerializeField] private Image completedText;
        [SerializeField] private Transform completedTextPosition,replayButtonPosition,door;
        
        private bool enableFinishingLevel = false;
        private float fadeSpeed = 0.25f,doorSpeed=0.75f;

        private CanvasGroup doorImage;
        
        #endregion

        #region Unity Methods

        private void Start()
        {
            doorImage = transform.GetComponent<CanvasGroup>();
            StartCoroutine(FadeImage());
            replayButton.onClick.AddListener(LoadScene);
        }
        
        #endregion

        #region Private Methods

        IEnumerator FadeImage()
        {
            yield return new WaitForSeconds(2);
            doorImage.DOFade(1, fadeSpeed).OnComplete(() => enableFinishingLevel=true);
        }
        private void LoadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

                completedText.transform.DOMove(completedTextPosition.position, fadeSpeed).SetEase(Ease.OutBack);
                replayButton.transform.DOMove(replayButtonPosition.position, fadeSpeed).SetEase(Ease.OutBack);

                door.DORotate(new Vector3(0, -50, 0), doorSpeed);
                doorImage.DOFade(0, fadeSpeed);
            }
        }
        #endregion
    }
}
