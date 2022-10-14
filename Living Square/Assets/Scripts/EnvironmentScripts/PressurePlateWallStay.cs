using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateWallStay : MonoBehaviour
{
    public GameObject anInteractObj;
    private Animator anInteractObjAnimator;

    // Start is called before the first frame update
    void Start()
    {
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
        Invoke(nameof(close), 0f);

    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Pickable")
        {
            Invoke(nameof(open), 0f);
        }
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
