using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIService uiService;
    [SerializeField] private float levelDuration = 180;

    private int cakesSlices = 0;
    private float timer;

    private void Awake()
    {
        GameplayEvent.OnCakeCut += HandelOnCakeCut;
    }

    private void OnDestroy()
    {
        GameplayEvent.OnCakeCut -= HandelOnCakeCut;
    }

    private void HandelOnCakeCut()
    {
        uiService.UpdateCakeAmount(++cakesSlices);
    }

    private void Start()
    {
        uiService.UpdateCakeAmount(cakesSlices);
        timer = levelDuration;
    }
    
    
    
    private void Update()
    {
        if(timer == 0)
        {
            return;
        }

        timer = Mathf.Max(0, timer - Time.deltaTime);
        uiService.UpdateTimer(timer);

        if(timer == 0 )
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        uiService.OpenEndGamePopup();
    }
}
