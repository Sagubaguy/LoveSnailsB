using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float InteractTimer = 2;
    public bool IsInteracting = false;
    public GameObject CameraTarget;

    private float nextInteract = 0;
    private Vector3 camOffset;

    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - CameraTarget.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInteracting)
        {
            if(Time.time > nextInteract)
            {
                IsInteracting = false;
                nextInteract = 0;
            }
        }

        //CameraTarget.transform.position = transform.position + camOffset;
    }

    public void SetInteract()
    {
        IsInteracting = true;
        nextInteract = Time.time + InteractTimer;
    }
}
