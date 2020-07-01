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
        
        // String list of the names of attacks. One Handed and Two Handed
        public string[] oh_attacks;
        public string[] th_attacks;
        
        //Variable to activate two handed carry
        public bool twoHanded;
        
        //See if roor motion is enabled. Only for attacks.
        public bool enableRootMotion;

        public bool useItem;
        public bool interacting;
        
        
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

            //CanMove is a variable that lets me know if i can apply root motion
            
            bool cannotMove = !anim.GetBool("CanMove");
            enableRootMotion = !anim.GetBool("CanMove");
            
            // I want to apply root motion only if I am attacking (Cannot move)
            anim.applyRootMotion = !anim.GetBool("CanMove");


            interacting = anim.GetBool("interacting");
            
            //If I cannot move because I'm attacking, I get out of the Update Loop
            if (cannotMove)
                return;
            
            if (useItem)
            {
                anim.CrossFade("use_item", 0.2f);
                useItem = false;
            }

            if (interacting)
            {
                playAnim = false;
                vertical = Mathf.Clamp(vertical, 0, 0.5f);
                print("jajajajajaja");
            }
            
            //Check if we press "Two handed"
            anim.SetBool("Two_Handed", twoHanded);

            if (playAnim)
            {
                string targetAnim;
                //If not two handed, choose one handed attacks
                if (!twoHanded)
                {
                    int r = Random.Range(0, oh_attacks.Length);
                    targetAnim = oh_attacks[r];

                    if (vertical > 0.5f)
                    {
                        targetAnim = "oh_attack_3";
                    }
                }
                //If two handed, choose two handed attacks
                else
                {
                    int r = Random.Range(0, th_attacks.Length);
                    targetAnim = th_attacks[r];
                }
                
                if (vertical > 0.5f)
                {
                    targetAnim = "oh_attack_3";
                }fr
                //Vertical is the variable to blend walk and running animation.
                //Since we are attacking, it must be 0.
                vertical = 0;
                //we crossfade de selected attacking animation
                anim.CrossFade(targetAnim, 0.1f);
                //When we are done, play anim goes false again.
                playAnim = false;
            }
            
            anim.SetFloat("Vertical", vertical);
            
        }
    }

    
     
}  


