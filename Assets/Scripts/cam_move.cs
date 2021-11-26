using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using PathCreation;

public class cam_move : MonoBehaviour
{
    [SerializeField]
    private Transform target;
 
    [SerializeField]
    private Vector3 offsetPosition;
 
    [SerializeField]
    private Space offsetPositionSpace = Space.Self;
 
    [SerializeField]
    private bool lookAt = true;
 
    private void Update()
    {
        Refresh();
    }
 
    public void Refresh()
    {
        if(target == null)
        {
            Debug.LogWarning("Missing target ref !", this);
 
            return;
        }
 
        // compute position
        if(offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }
 
        // compute rotation
        if(lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
    //public GameObject player;

    //private Vector3 offsetPosition = new Vector3(-1.4f, 0.6f, -0.0f); //posizione iniziale camera
    //private Quaternion offsetRotation;// = new Vector3(15, 90, 0);

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    //void Update()
    //{
        //transform.position = player.transform.position + offsetPosition;
        //transform.rotation = player.transform.rotation; //* offsetRotation;// * Quaternion.Euler(offsetRotation);
   // }
}