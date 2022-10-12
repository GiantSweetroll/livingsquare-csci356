using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float speed = 5f;

    private bool isActivated = false, isTransitioning = false;
    private Vector3 originalPos;
    private float targetPosActivated;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        targetPosActivated = originalPos.y - transform.localScale.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (isTransitioning)
        {
            Vector3 pos = transform.position;
            if (!isActivated)
            {
                // go down until half its Y scale
                if (transform.position.y > targetPosActivated)
                {
                    pos.y -= speed * Time.deltaTime;
                    transform.position = pos;
                }
                else
                {
                    isActivated = true;
                    isTransitioning = false;
                }
            }
            else
            {
                // go up until its orginal position
                if (transform.position.y < originalPos.y)
                {
                    pos.y += speed * Time.deltaTime;
                    transform.position = pos;
                }
                else
                {
                    isActivated = false;
                    isTransitioning = false;
                }
            }
        }
        */
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Pickable")
        {
 //           isTransitioning = true;
            // TODO: Do something
            Debug.Log("Pressure Plate activated");
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Pickable")
        {
 //           isTransitioning = true;
            // TODO: Do something
            Debug.Log("Pressure Plate deactivated");
        }
    }
}
