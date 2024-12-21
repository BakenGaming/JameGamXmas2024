using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using CodeMonkey.Utils;

public class PlayerInputController_TopDown : MonoBehaviour, IInputHandler
{
    #region Events
    public static OnFireWeapon OnPlayerAttack;
    public static OnThrowPresent OnPlayerThrowPresent;
    public static event Action<float> OnBoostingActive;
    public static event Action<int> OnCookieShot;
    public static event Action<int> OnPresentThrown;
    public static event Action<LootType, float> OnItemCollected;
    public static Action OnPauseGame;
    public static Action OnUnpauseGame;
    #endregion

    #region Variables
    public delegate void OnFireWeapon(Vector3 mousePos);
    public delegate void OnThrowPresent(Vector3 mousePos);
    private StatSystem _playerStats;
    private InputAction _move, _attack, _throw, _boost, _pause;
    private GameControls _controller;
    private Vector2 moveInput, lookDir;
    private Rigidbody2D playerRB;
    private Camera mainCam;
    private bool gameStarted;
    private float attackTimer=0, presentTimer=0,boostAmount;
    private bool boostAvailable, boostActive;
    private int cookieCount, presentCount;

    #endregion

    #region Initialize
    public void Initialize()
    {
        _playerStats = GetComponent<IHandler>().GetStatSystem();    
        _controller = new GameControls();
        playerRB = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;

        _move = _controller.TopDownControls.MoveInput;
        _move.Enable();

        _attack = _controller.TopDownControls.Attack;
        _attack.performed += HandleAttackInput;
        _attack.Enable();
        
        _throw = _controller.TopDownControls.Throw;
        _throw.performed += HandleThrowInput;
        _throw.Enable();

        _pause = _controller.TopDownControls.Pause;
        _pause.performed += HandlePauseInput;
        _pause.Enable();

        _boost = _controller.TopDownControls.Boost;
        _boost.started += HandleBoostInputActivate;
        _boost.canceled += HandleBoostInputDeactivate;
        _boost.Enable();

        boostAmount = _playerStats.GetBoostAmount();
        boostAvailable = true;
        boostActive = false;

        cookieCount = _playerStats.GetCookieMax();
        presentCount = _playerStats.GetPresentMax();

        Cookie.OnCookieCollected += CollectCookie;
        CandyCane.OnCandyCaneCollected += CollectCandyCane;    

    }


    private void OnDisable()
    {
        _move.Disable();
        _attack.Disable();
        _throw.Disable();
        _pause.Disable();

        Cookie.OnCookieCollected -= CollectCookie;
        CandyCane.OnCandyCaneCollected -= CollectCandyCane;    
    }
    #endregion

    #region Input Handling
    private void HandleAttackInput(InputAction.CallbackContext context)
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        if(attackTimer <= 0 && cookieCount > 0) 
        {
            OnPlayerAttack?.Invoke(aimDirection);
            cookieCount--;
            OnCookieShot?.Invoke(cookieCount);
            attackTimer = _playerStats.GetTimeBetweenShots();
        }
        
    }
    private void HandleThrowInput(InputAction.CallbackContext context)
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        if(presentTimer <= 0 && presentCount > 0) 
        {
            OnPlayerThrowPresent?.Invoke(aimDirection);
            presentCount--;
            OnPresentThrown?.Invoke(presentCount);
            presentTimer = _playerStats.GetTimeBetweenThrows();
        }
        
    }
    private void HandleBoostInputActivate(InputAction.CallbackContext context)
    {
        if(boostAvailable) boostActive = true;
    }
    private void HandleBoostInputDeactivate(InputAction.CallbackContext context)
    {
        if(boostActive) boostActive = false;
    }
    private void HandlePauseInput(InputAction.CallbackContext context)
    {
        if(!GameManager.i.GetIsPaused()) OnPauseGame?.Invoke();
        else OnUnpauseGame?.Invoke();

    }

    #endregion

    #region Loop
    private void Update() 
    {
        UpdateTimers();
        if(!GameManager.i.GetIsPaused()) moveInput = _move.ReadValue<Vector2>();
        else playerRB.velocity = Vector2.zero;
    }

    private void FixedUpdate() 
    {
        if(GameManager.i.GetIsPaused()) 
        {
            playerRB.velocity = Vector2.zero;
            return;
        }
        
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = mainCam.WorldToScreenPoint(transform.localPosition);
       
        Vector2 moveSpeed = moveInput.normalized;
        if(!boostActive) playerRB.velocity = new Vector2(moveInput.x * _playerStats.GetMoveSpeed(), moveInput.y * .5f * _playerStats.GetMoveSpeed());    
        else BoostMovement(moveSpeed);
    }

    private void BoostMovement(Vector2 moveSpeed)
    {
        playerRB.velocity = new Vector2(moveInput.x * _playerStats.GetMoveSpeed(), MathF.Abs(moveInput.y) * .5f * (_playerStats.GetMoveSpeed() *2.5f));    
    }
    private void UpdateTimers()
    {
        if(boostActive)
        {
            boostAmount -= Time.deltaTime;
            OnBoostingActive?.Invoke(boostAmount);
            if(boostAmount <= 0)
            {
                boostAmount = 0;
                boostAvailable = false;
            }
        }
        presentTimer -= Time.deltaTime;
        attackTimer -= Time.deltaTime;
    }

    #endregion
    #region CollectedItems
    private void CollectCookie(int _value)
    {
        cookieCount = _playerStats.GetCookieMax(); 
        OnItemCollected?.Invoke(LootType.cookies, cookieCount);
    }

    private void CollectCandyCane(float _value)
    {
        boostAmount += _value;
        if(boostAmount >= _playerStats.GetPresentMax()) boostAmount = _playerStats.GetPresentMax();
        OnItemCollected?.Invoke(LootType.cookies, boostAmount);
    }
    #endregion
    #region Checks

    #endregion
}
