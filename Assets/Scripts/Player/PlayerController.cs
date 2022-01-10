using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Step;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        
    #region Singleton

    private static PlayerController _Instance=null;
    public static PlayerController Instance
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
    public static event Action OnClickedEvent;
    private Ray ray;
    
    private string _chosenObject= " ";
    private bool isClicked = false;

    private Camera cam;
    #endregion

    #region Properties

    public string chosenObject
    {
        get
        {
            return _chosenObject;
        }
        set
        {
            _chosenObject = value;
        }
    }

    #endregion

    #region Unity Methods

    private void Start()
    {
        cam=Camera.main;
    }

    private void Update()
    {
        ChooseObject();
    }

    #endregion

    #region Private Methods

    private void ChooseObject()
    {
        if (!isClicked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isClicked = true;
                
                ray = cam.ScreenPointToRay((Input.mousePosition));
                RaycastHit hit;
                    
                if (Physics.Raycast(ray,out hit, Mathf.Infinity))
                {
                    if(!hit.transform.CompareTag("Untagged"))
                    {
                        chosenObject = hit.transform.tag;
                        if (OnClickedEvent != null)
                        {
                            OnClickedEvent();
                        }
                    }
                            
                } 
                else
                {
                    chosenObject = " ";
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
        }
    }
    
    #endregion
    }
}

