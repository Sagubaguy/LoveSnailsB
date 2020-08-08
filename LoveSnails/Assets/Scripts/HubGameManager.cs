using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConvoStatus { InHub, InConvo };

public class HubGameManager : MonoBehaviour
{
    //lazy singleton
    public static HubGameManager Instance;

    public Camera ThirdPersonCam;
    public Camera FlowchartCam;
    public GameObject PlayerObject;

    private ConvoStatus ConversationStatus;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        ConversationStatus = ConvoStatus.InHub;
    }

    public void SwapCamera()
    {
        if(ConversationStatus == ConvoStatus.InHub)
        {
            PlayerObject.SetActive(false);
            ThirdPersonCam.gameObject.SetActive(false);
            FlowchartCam.gameObject.SetActive(true);
            ConversationStatus = ConvoStatus.InConvo;
        }
        else if (ConversationStatus == ConvoStatus.InConvo)
        {
            PlayerObject.SetActive(true);
            FlowchartCam.gameObject.SetActive(false);
            ThirdPersonCam.gameObject.SetActive(true);
            ConversationStatus = ConvoStatus.InHub;
        }
    }
}
