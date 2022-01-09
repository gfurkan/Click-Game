using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Player;

namespace Step
{
    public class StepContoller : MonoBehaviour
    {
        #region Fields

        [SerializeField] private ParticleSystem particle;
        protected GameObject glassObject;
        protected PlayerController playerController;

        #endregion

        #region Unity Methods

        private void Start()
        {
            playerController=PlayerController.Instance;
            glassObject = GameObject.FindGameObjectWithTag("Glass");
        }

        #endregion
        
        #region Public Methods

        public virtual void ChangeMaterial(GameObject obj,Material mat)
        {
            obj.GetComponent<MeshRenderer>().material = mat;
        }

        public virtual void MoveObject(Transform obj, Vector3 position)
        {
            obj.DOMove(position, 0.5f);
        }

        public virtual void ChangeStringValues()
        {
            playerController.ChangeStringValues();
        }

        public virtual void PlayParticle()
        {
            particle.Play();
        }
        #endregion
    }
}

