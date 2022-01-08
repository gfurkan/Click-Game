using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace Player
{
    public class PlayerController : MonoBehaviour
{
    #region Fields

    private static PlayerController _Instance;

    public static PlayerController Instance
    {
        get
        {
            return _Instance;
        }
    }
    
    public string firstChosenObject,secondChosenObject;
    private int chosenObjectCount=0;
    private bool clicked = false;
    public bool compareObject = false;
    private Ray ray;
        
    #endregion

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
    }

    private void Update()
    {
        ChooseObject();
    }

    private void ChooseObject()
            {
                if (!clicked)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        clicked = true;
                        ray = Camera.main.ScreenPointToRay((Input.mousePosition));
                        RaycastHit hit;
                    
                        if (Physics.Raycast(ray,out hit, Mathf.Infinity))
                        {
                            if(hit.transform.tag!="Untagged")
                            {
                                if (chosenObjectCount>=2)
                                {
                                    chosenObjectCount = 0;
                                }
                                if (chosenObjectCount.Equals(1))
                                {
                                    secondChosenObject = hit.transform.gameObject.tag;
                                    chosenObjectCount++;
                                    compareObject = true;
                                }
                                if (chosenObjectCount.Equals(0))
                                {
                                    firstChosenObject = hit.transform.gameObject.tag;
                                    chosenObjectCount++;
                                }
                            }
                            
                        } 
                        else
                        {
                            chosenObjectCount = 0;
                        }
                    }

                    
                }
                if (Input.GetMouseButtonUp(0))
                {
                    clicked = false;
                    compareObject = false;
                }
            }
      }
}

