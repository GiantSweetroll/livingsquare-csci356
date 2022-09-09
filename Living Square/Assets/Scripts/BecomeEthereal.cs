using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeEthereal : MonoBehaviour
{
    public GameObject spiritObject, camera;
    public float duration = 5;

    private Transform physicalBodyTf;
    private bool isEthereal = false;
    private PlayerControls physicalBodyControl, etherealBodyControl;
    private RotationController cameraRotation;
    private float etherealTimer;

    // Start is called before the first frame update
    void Start()
    {
        physicalBodyTf = gameObject.transform;
        physicalBodyControl = gameObject.GetComponent<PlayerControls>();
        etherealBodyControl = spiritObject.GetComponent<PlayerControls>();
        cameraRotation = camera.GetComponent<RotationController>();

        etherealBodyControl.enabled = false;

        etherealTimer = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEthereal)
        {
            // If the ethereal mode timer ran out, return to physical body
            if (etherealTimer <= 0)
                SwitchEtherealMode(false);
            // Otherwise, reduce the timer every second
            else
                etherealTimer -= Time.deltaTime;
        }

        // TODO: Decide best key to toggle power
        // Switch between physical body and ethereal form (and vice versa) using
        // a key toggle
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SwitchEtherealMode(!isEthereal);
        }
    }

    private void SwitchEtherealMode(bool isEthereal)
    {
        this.isEthereal = isEthereal;

        // If not ethereal, return spirit to physical body
        spiritObject.transform.position = physicalBodyTf.position;
        spiritObject.transform.rotation = physicalBodyTf.rotation;

        // Turn on/off physical body control and ethereal form control
        physicalBodyControl.enabled = !isEthereal;
        etherealBodyControl.enabled = isEthereal;

        // Change the parent/child heirarchy of the camera
        camera.transform.parent = isEthereal ? spiritObject.transform : gameObject.transform;
        cameraRotation.character = isEthereal ? spiritObject : gameObject;

        // Update timer
        if (isEthereal)
            etherealTimer = duration;
    }
}
