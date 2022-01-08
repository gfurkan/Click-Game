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

    [SerializeField] private GlassDispenseStep glassDispenseStep;
    [SerializeField] private VaseStep vaseStep;
    [SerializeField] private TrashStep trashStep;
    [SerializeField] private DoorStep doorStep;
    private static PlayerController _Instance;
    public static PlayerController Instance
    {
        get
        {
            return _Instance;
        }
    }


    [SerializeField] private Transform[] stepTransforms;
    public GameObject chosenObject;
    public string firstChosenObject,secondChosenObject;
    private int chosenObjectCount=0,stepCounter=0;
    private bool clicked = false;
    public bool compareObject = false;
    private float movementTime = 1;
    private Ray ray;
    public enum Steps
    {
        board,dispenser,vase,trash,door
    }

    public Steps step;
    
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

        switch (step)
        {
            case Steps.board:
                transform.DOMove(stepTransforms[(int) Steps.board].position, movementTime);
                transform.DORotate(stepTransforms[(int) Steps.board].eulerAngles, movementTime);
                break;
            case Steps.dispenser:
                glassDispenseStep.enabled = true;
                transform.DOMove(stepTransforms[(int) Steps.dispenser].position, movementTime);
                transform.DORotate(stepTransforms[(int) Steps.dispenser].eulerAngles, movementTime);
                break;
            case Steps.vase:
                vaseStep.enabled = true;
                transform.DOMove(stepTransforms[(int) Steps.vase].position, movementTime);
                transform.DORotate(stepTransforms[(int) Steps.vase].eulerAngles, movementTime);
                break;
            case Steps.trash:
                trashStep.enabled = true;
                transform.DOMove(stepTransforms[(int) Steps.trash].position, movementTime);
                transform.DORotate(stepTransforms[(int) Steps.trash].eulerAngles, movementTime);
                break;
            case Steps.door:
                doorStep.enabled = true;
                transform.DOMove(stepTransforms[(int) Steps.door].position, movementTime*2);
                transform.DORotate(stepTransforms[(int) Steps.door].eulerAngles, movementTime*2);
                break;
        }
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
                                    chosenObject = hit.transform.gameObject;
                                    compareObject = true;
                                }
                                if (chosenObjectCount.Equals(0))
                                {
                                    firstChosenObject = hit.transform.gameObject.tag;
                                    chosenObject = hit.transform.gameObject;
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

    public void IncreaseStepCounter()
    {
        stepCounter++;
        
    }
      }
}

