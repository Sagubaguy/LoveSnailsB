using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using Fungus;

public class StartDialogue : MonoBehaviour
{
    public string SceneNameToOpen;
    public Flowchart Dialogueflowchart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKey(KeyCode.Space)){
            Dialogueflowchart.ExecuteBlock("Start");
            HubGameManager.Instance.SwapCamera();
            //SceneManager.LoadScene(SceneNameToOpen);
        }
    }
}
