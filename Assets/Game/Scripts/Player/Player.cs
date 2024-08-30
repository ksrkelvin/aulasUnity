using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool isPaused;

    [SerializeField]private float speed;
    [SerializeField]private float runSpeed;
    

    private Rigidbody2D rig;
    private PlayeItems playerItems;
    private float initialSpeed;
    private int _handlingObj;
    private Vector2 _direction;

    private bool _isRunning;
    private bool _isRolling;
    private bool _isDigging;
    private bool _isCutting;
    private bool _isWatering;


    public Vector2 direction 
    { 
        get => _direction; 
        set => _direction = value; 
    }

    public bool isRunning 
    { 
        get => _isRunning; 
        set => _isRunning = value; 
    }


    public bool isRolling 
    { 
        get => _isRolling; 
        set => _isRolling = value; 
    }


    public bool isDigging
    { 
        get => _isDigging; 
        set => _isDigging = value; 
    }

    public bool isCutting 
    { 
        get => _isCutting; 
        set => _isCutting = value; 
    }

    public bool isWatering 
    { 
        get => _isWatering; 
        set => _isWatering = value; 
    }

    public int handlingObj 
    { 
        get => _handlingObj; 
        set => _handlingObj = value; 
    }





    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerItems = GetComponent<PlayeItems>();
        initialSpeed = speed;
    }

    private void Update()
    {
        if (!isPaused)
        {
            OnInput();
            OnRun();
            OnRolling();
            ChangeHandlingObj();
            OnAction();
        }

        
        
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            OnMove();
        }
    }
     

    #region Inputs

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void ChangeHandlingObj()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlingObj = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handlingObj = 1;
        }
          if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            handlingObj = 2;
        }

    }

    #endregion


    #region Movement

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    
    }
    void OnAction(){
        switch (handlingObj)
            {
                case 0:
                    OnCutting();
                    break;
                case 1:
                    OnDigging();
                    break;
                case 2:
                    OnWatering();
                    break;
            }
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRolling = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRolling = false;
        }
    }

    void OnDigging()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speed = 0;
            isDigging = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            speed = initialSpeed;
            isDigging = false;
        }
    }

    void OnCutting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speed = 0;
            isCutting = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            speed = initialSpeed;
            isCutting = false;
        }
    }

      void OnWatering()
    {
        if (Input.GetMouseButtonDown(0) && playerItems.currentWater > 0)
        {
            speed = 0;
            isWatering = true;
        }
        if (Input.GetMouseButtonUp(0) || playerItems.currentWater < 0)
        {
            speed = initialSpeed;
            isWatering = false;
        }

        if (isWatering){
            playerItems.currentWater-=0.1f;
        }
    }



    
    #endregion

}
