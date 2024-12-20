using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    #region Events
    
    #endregion

    #region Variables
    [SerializeField] private TextMeshProUGUI cookieText;
    [SerializeField] private TextMeshProUGUI presentText;
    [SerializeField] private TextMeshProUGUI boostText;

    private bool gameStarted=false;

    #endregion

    #region Initialize
    private void OnEnable() 
    {
        GameManager.onGameReady += Initialize;    
    }
    private void Initialize()
    {
        PlayerInputController_TopDown.OnBoostingActive += UpdateBoostUI;
        PlayerInputController_TopDown.OnCookieShot += UpdateCookieUI;
        PlayerInputController_TopDown.OnPresentThrown += UpdatePresentUI;
        PlayerInputController_TopDown.OnItemCollected += HandleUIOnCollection;
        UpdateCookieUI(GameManager.i.GetInitialCookieCount());
        UpdatePresentUI(GameManager.i.GetInitialPresentCount());
        UpdateBoostUI(GameManager.i.GetInitialBoost());
    }

    private void OnDisable() 
    {
        GameManager.onGameReady -= Initialize;
        PlayerInputController_TopDown.OnBoostingActive -= UpdateBoostUI;
        PlayerInputController_TopDown.OnCookieShot -= UpdateCookieUI;
        PlayerInputController_TopDown.OnPresentThrown -= UpdatePresentUI;
    }

    #endregion

    #region UI Updates

    private void HandleUIOnCollection(LootType _type, float _value)
    {
        switch(_type)
        {
            case LootType.cookies:
            UpdateCookieUI((int)_value);
            break;

            case LootType.candyCane:
            UpdateBoostUI(_value);
            break;

            default: break;
        }
    }

    private void UpdateCookieUI(int _count)
    {
        cookieText.text = "COOKIES : " + _count.ToString();
    }

    private void UpdatePresentUI(int _count)
    {
        presentText.text = "PRESENTS : " + _count.ToString();
    }

    private void UpdateBoostUI(float _amount)
    {
        boostText.text = "BOOST : " + _amount.ToString("##.#");
    }
    #endregion
}
