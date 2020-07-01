using System;
using System.Collections;
using System.Collections.Generic;
using j_sevamo;
using UnityEngine;


using UnityEditor;

public class InputHandler : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    private StateManager states;

    private CameraManager camManager;

    private float delta;
    
    // Start is called before the first frame update
    void Start()
    {
        states = GetComponent<StateManager>();
        states.Init();

        camManager = CameraManager.singleton;
        camManager.Init(this.transform);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        delta = Time.fixedDeltaTime;
        GetInput();
    }

    private void Update()
    {
        delta = Time.deltaTime;
        camManager.Tick(delta);
        
    }


    void GetInput()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal"); 
    }

    void UpdateStates()
    {
        states.horizontal = horizontal;
        states.vertical = vertical;
        
        states.Tick(delta);
    }
}
