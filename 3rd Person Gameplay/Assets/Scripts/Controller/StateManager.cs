using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace j_sevamo
{
    public class StateManager : MonoBehaviour
    {
        public float horizontal;
        public float vertical;

        public GameObject activeModel;
        [HideInInspector]
        public Animator anim;
        [HideInInspector]
        public Rigidbody rigid;
        [HideInInspector]
        public float delta;

        public void Init()
        {
            SetupAnimator();
            rigid = GetComponent<Rigidbody>();
        }

        void SetupAnimator()
        {
                      
            if (activeModel == null)
            {
                anim = GetComponentInChildren<Animator>();
                if (anim == null)
                {
                    Debug.Log("No model found");
                }
                else
                {
                    activeModel = anim.gameObject;
                }
            }

            if(anim == null)
                anim = activeModel.GetComponent<Animator>();

            anim.applyRootMotion = false;
        }

        public void Tick(float d)
        {
            delta = d;
        }
    }

}
