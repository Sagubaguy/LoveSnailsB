using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClick : MonoBehaviour
{
    public Camera PlayerCam;
    public SnailMover PlayerMover;
    public Transform CameraTarget;

    bool IsMoveEnabled = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && IsMoveEnabled)
        {
            Ray ray = PlayerCam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                PlayerMover.MoveTo(hit.point);
                // Do something with the object that was hit by the raycast.
            }

            //this.transform.position = CameraTarget.position;
        }

        
    }

    public void EnableMove()
    {
        IsMoveEnabled = true;
        transform.position = CameraTarget.position;
        transform.rotation = CameraTarget.rotation;
    }

    public void DisableMove()
    {
        IsMoveEnabled = false;

    }
}
