using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeEthereal : MonoBehaviour
{
    public GameObject spiritObject, camera;
    public float duration = 20;

    private Transform physicalBodyTf;
    private bool isEthereal = false;
    private PlayerControls physicalBodyControl, etherealBodyControl;
    private RotationController cameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        physicalBodyTf = gameObject.transform;
        physicalBodyControl = gameObject.GetComponent<PlayerControls>();
        etherealBodyControl = spiritObject.GetComponent<PlayerControls>();
        cameraRotation = camera.GetComponent<RotationController>();

        etherealBodyControl.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isEthereal = !isEthereal;

            // If not ethereal, return spirit to physical body
            spiritObject.transform.position = physicalBodyTf.position;
            spiritObject.transform.rotation = physicalBodyTf.rotation;

            // Turn on/off physical body control and ethereal form control
            physicalBodyControl.enabled = !isEthereal;
            etherealBodyControl.enabled = isEthereal;

            // Change the parent/child heirarchy of the camera
            camera.transform.parent = isEthereal ? spiritObject.transform : gameObject.transform;
            cameraRotation.character = isEthereal ? spiritObject : gameObject;
        }
    }
}
