using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SnailMover : MonoBehaviour
{
    public float MoveSpeed = 5;
    public GameObject SnailModel;
    

    Rigidbody rigidbody;
    public AudioSource audioSrc;
    public NavMeshAgent agent;
    private bool isMoving = false;

    private Vector3 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //inputVector = Vector3.zero;

        //inputVector.x = Input.GetAxis("Horizontal");
        //inputVector.z = Input.GetAxis("Vertical");

        //if (inputVector != Vector3.zero)
        //{
        //    SnailModel.transform.forward = inputVector;
        //}

        if (agent.velocity.x !=0 || agent.velocity.z !=0)
        {
            isMoving = true;

        }
        else
        {
            isMoving = false;
        }

        if (isMoving && !audioSrc.isPlaying)
        {
            audioSrc.Play();
        }
        if (!isMoving && audioSrc.isPlaying)
        {
            audioSrc.Stop();
        }


    }

    //void FixedUpdate()
    //{
    //    rigidbody.MovePosition(rigidbody.position + inputVector * MoveSpeed * Time.fixedDeltaTime);
    //}


    public void MoveTo(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public void StopMoving()
    {
        agent.Stop();
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
    }

}
