using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float SENS_HOR = 3.0F;
    public float SENS_VER = 2.0F;
    GameObject character;      // A parent object the camera is attached to

    // Start is called before the first frame update
    void Start()
    {
        // disable the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        // assign a parent object of this object
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseMove = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseMove = Vector2.Scale(mouseMove, new Vector2(SENS_HOR, SENS_VER));
        // rotate the character horizontally
        character.transform.Rotate(0, mouseMove.x, 0);
        transform.Rotate(-mouseMove.y, 0, 0);

        // enable the mouse cursor if Esc pressed
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
