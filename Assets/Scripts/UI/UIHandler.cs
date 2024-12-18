using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    #region Events
    public static event Action<int> OnLaunchSled;
    #endregion

    #region Variables
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI timerText;
    
    private float countDownTimer;
    private int mainCount, maxCount;
    private bool gameStarted=false, isLaunching=false;

    #endregion

    #region Initialize
    public void Initialize()
    {
        mainCount = 0;
        countDownTimer = GameManager.i.GetStatSystem().GetClickTimer();
        maxCount = GameManager.i.GetStatSystem().GetMaxCount();
        UpdateUI();
        
    }

    #endregion

    #region Loop
    public void OnButtonClick()
    {
        if(!gameStarted) gameStarted = true;

        if(countDownTimer >= 0 && mainCount < maxCount)
        {
            mainCount++;
        }
    }

    private void Update() 
    {
        UpdateUI();
        if(gameStarted && countDownTimer >= 0) countDownTimer -= Time.deltaTime;   

        if(!isLaunching && countDownTimer <= 0) 
        {
            isLaunching = true;
            OnLaunchSled?.Invoke(mainCount); 
        }
    }

    private void UpdateUI()
    {
        countText.text = mainCount.ToString();
        
        if(countDownTimer > 0) timerText.text = countDownTimer.ToString("##.#");
        else timerText.text = "0";
    }
    #endregion
}
