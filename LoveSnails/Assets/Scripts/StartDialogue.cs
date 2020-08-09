using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using Fungus;

public class StartDialogue : MonoBehaviour
{
    //Should be the name of the starting block in the flowchart
    public string StartingBlockName = "Start";

    //Should be the flow chart that needs to be run on collision.
    public Flowchart Dialogueflowchart;

    private void OnTriggerEnter(Collider other)
    {
        //ONLY DO THIS FOR PLAYER (or Any rigidbody with a collider will start conversations
        Player playerComponent = other.GetComponent<Player>();
        if (playerComponent != null)
        {
            //if (!playerComponent.IsInteracting)
            //{
                //Start the flowchart
                Dialogueflowchart.ExecuteBlock(StartingBlockName);

                //Stop the player's current movement if they enter a conversation
                SnailMover playerMover = GetComponent<SnailMover>();
                if (playerMover)
                {
                    playerMover.StopMoving();
                }
                //Disable Player Here?  Or in Flowchart
            //}
        }
    }
}
