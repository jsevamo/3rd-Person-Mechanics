using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  SA
{
    public class Helper : MonoBehaviour
    {

        [Range(0, 1)] public float vertical;
        private Animator anim;
        public bool playAnim;

        public string[] oh_attacks;
        public string[] th_attacks;

        public bool twoHanded;
        
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            anim.SetBool("Two_Handed", twoHanded);
            
            if (playAnim)
            {
                string targetAnim;

                if (!twoHanded)
                {
                    int r = Random.Range(0, oh_attacks.Length);
                    targetAnim = oh_attacks[r];
                }
                else
                {
                    int r = Random.Range(0, th_attacks.Length);
                    targetAnim = th_attacks[r];
                }
                
                vertical = 0;
                anim.CrossFade(targetAnim, 0.6f);
                playAnim = false;
            }
            
            anim.SetFloat("Vertical", vertical);
        }
    }

    
     
}  


