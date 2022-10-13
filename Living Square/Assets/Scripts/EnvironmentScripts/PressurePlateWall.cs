using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateWall : MonoBehaviour
{
    public GameObject anInteractObj;
    private Animator WallAnimator;
    private Animator anInteractObjAnimator;

    // Start is called before the first frame update
    void Start()
    {
        WallAnimator = GetComponent<Animator>();
        anInteractObjAnimator = anInteractObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*==============================================================================
                                    ON_TRIGGER_EXIT
    ==============================================================================*/
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Pickable")
        {
            Invoke(nameof(close), 0f);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Pickable")
        {
            Invoke(nameof(open), 0f);
        }
    }


    void up()
    {
        WallAnimator.SetTrigger("Up");
        Invoke(nameof(idle), 1f);
    }

    void idle()
    {
        WallAnimator.SetTrigger("Idle");
    }

    void open()
    {
        anInteractObjAnimator.SetTrigger("Open");
    }

    void close()
    {
        anInteractObjAnimator.SetTrigger("Close");
        Invoke(nameof(reset), 2f);
    }

    void reset()
    {
        anInteractObjAnimator.SetTrigger("Idle");
    }
}
