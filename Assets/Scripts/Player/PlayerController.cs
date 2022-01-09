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

    [SerializeField] private GlassDispenseStep glassDispenseStep;
    [SerializeField] private VaseStep vaseStep;
    [SerializeField] private TrashStep trashStep;
    [SerializeField] private DoorStep doorStep;
    
    [SerializeField] private Transform[] stepTransforms;

    public enum Steps
    {
        board,dispenser,vase,trash,door
    }
    public Steps step;

    private int chosenObjectCount=0,stepCounter=0;
    private float movementTime = 1;
    
    private string _firstChosenObject= " ",_secondChosenObject= " ";
    private bool _clicked = false;
    
    private Ray ray;
    
    #endregion

    #region Properties

    public string firstChosenObject
    {
        get
        {
            return _firstChosenObject;
        }
        set
        {
            _firstChosenObject = value;
        }
    }

    public string secondChosenObject
    {
        get
        {
            return _secondChosenObject;
        }
        set
        {
            _secondChosenObject = value;
        }
    }

    public bool clicked
    {
        get
        {
            return _clicked;
        }
    }
    
    #endregion

    #region Unity Methods

    private void Update()
    {
        ChooseObject();
        ControlSteps();
    }

    #endregion

    #region Private Methods

    private void ChooseObject()
    {
        if (!_clicked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _clicked = true;
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
                            _secondChosenObject = hit.transform.gameObject.tag;
                            chosenObjectCount++;
                        }
                        if (chosenObjectCount.Equals(0))
                        {
                            _firstChosenObject = hit.transform.gameObject.tag;
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
            _clicked = false;
        }
    }

    private void ControlSteps()
    {
        switch (step)
        {
            case Steps.board:
                transform.DOMove(stepTransforms[(int) Steps.board].position, movementTime).SetEase(Ease.OutBack);
                transform.DORotate(stepTransforms[(int) Steps.board].eulerAngles, movementTime);
                break;
            case Steps.dispenser:
                glassDispenseStep.enabled = true;
                transform.DOMove(stepTransforms[(int) Steps.dispenser].position, movementTime).SetEase(Ease.OutBack);
                transform.DORotate(stepTransforms[(int) Steps.dispenser].eulerAngles, movementTime);
                break;
            case Steps.vase:
                vaseStep.enabled = true;
                transform.DOMove(stepTransforms[(int) Steps.vase].position, movementTime).SetEase(Ease.OutBack);
                transform.DORotate(stepTransforms[(int) Steps.vase].eulerAngles, movementTime);
                break;
            case Steps.trash:
                trashStep.enabled = true;
                transform.DOMove(stepTransforms[(int) Steps.trash].position, movementTime).SetEase(Ease.OutBack);
                transform.DORotate(stepTransforms[(int) Steps.trash].eulerAngles, movementTime);
                break;
            case Steps.door:
                doorStep.enabled = true;
                transform.DOMove(stepTransforms[(int) Steps.door].position, movementTime*2).SetEase(Ease.OutBack);
                transform.DORotate(stepTransforms[(int) Steps.door].eulerAngles, movementTime*2);
                break;
        }
    }

    #endregion

    #region Public Methods

    public void ChangeStringValues()
    {
        _firstChosenObject = " ";
        _secondChosenObject = " ";
    }

    #endregion
}
}

