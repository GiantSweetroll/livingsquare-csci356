using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Camera must ALWAYS be a child of an object (Physical or Ethereal body)
 * Otherwise this script will break and the world will explode :D
*/
public class CameraController : MonoBehaviour
{
    // Settings variables
    public float SENS_HOR = 3f;
    public float SENS_VER = 2f;

    // internal variables
    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        // disable the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // get inputs
        mouseX = Input.GetAxisRaw("Mouse X") * SENS_HOR;
        mouseY = Input.GetAxisRaw("Mouse Y") * SENS_VER;

        //rotate around y axis for body
        transform.parent.Rotate(0, mouseX, 0);
        //rotate camera according to mouse
        transform.Rotate(-mouseY, 0, 0);

        // enable the mouse cursor if Esc pressed
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
