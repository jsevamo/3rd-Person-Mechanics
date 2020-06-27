using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  SA
{
    public class Helper : MonoBehaviour
    {

        [Range(0, 1)] public float vertical;
        private Animator anim;
        
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            anim.SetFloat("Vertical", vertical);
        }
    }

    
     
}  


