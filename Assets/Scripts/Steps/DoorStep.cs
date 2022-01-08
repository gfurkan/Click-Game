using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorStep : MonoBehaviour,IPointerClickHandler
{
    private bool enableFinishingLevel = false;
    private void Start()
    {
        StartCoroutine(FadeImage());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("works");
        if (enableFinishingLevel)
        {
            Debug.Log("Level Finished");
        }
        
    }

    IEnumerator FadeImage()
    {
        yield return new WaitForSeconds(2);
        transform.GetComponent<CanvasGroup>().DOFade(1, 0.5f).OnComplete(() => enableFinishingLevel=true);
        
    }
}
