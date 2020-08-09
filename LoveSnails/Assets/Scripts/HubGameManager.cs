using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ConvoStatus { InHub, InConvo };

public class HubGameManager : MonoBehaviour
{
    //lazy singleton
    public static HubGameManager Instance;

    //CAMERA/PLAYER
    public Camera ThirdPersonCam;
    public Camera FlowchartCam;
    public GameObject PlayerObject;

    //TIMER
    public float TimerInSeconds = 480; //8 minutes default
    public float TimeRemaining = 0;
    public UnityEvent TimeIsUp;

    bool IsTimerActive = false;

    //private ConvoStatus ConversationStatus;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        //ConversationStatus = ConvoStatus.InHub;
    }

    public void TimerStart()
    {
        TimeRemaining = TimerInSeconds;
    }

    public void PauseTimer(bool pauseValue)
    {
        IsTimerActive = pauseValue;
        //Any other pause code goes here. 
    }

    private void Update()
    {
        if (!IsTimerActive)
        {
            TimeRemaining -= Time.deltaTime;
            if(TimeRemaining <= 0)
            {
                IsTimerActive = false;
                TimerEndCode();
            }
        }
    }

    public void TimerEndCode()
    {
        //PUT WHATEVER NEEDS TO TRIGGER ON TIMER END HERE
        //MADE AN EVENT IN CASE WE NEED TO TRIGGER MORE STUFF
        TimeIsUp.Invoke();
    }

    //public void SwapCamera()
    //{
    //    if(ConversationStatus == ConvoStatus.InHub)
    //    {
    //        PlayerObject.SetActive(false);
    //        ThirdPersonCam.gameObject.SetActive(false);
    //        FlowchartCam.gameObject.SetActive(true);
    //        ConversationStatus = ConvoStatus.InConvo;
    //    }
    //    else if (ConversationStatus == ConvoStatus.InConvo)
    //    {
    //        PlayerObject.SetActive(true);
    //        FlowchartCam.gameObject.SetActive(false);
    //        ThirdPersonCam.gameObject.SetActive(true);
    //        ConversationStatus = ConvoStatus.InHub;
    //    }
    //}
}
