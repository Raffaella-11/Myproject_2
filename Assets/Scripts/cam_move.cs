using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using PathCreation;

public class cam_move : MonoBehaviour
{
    public GameObject player;

    private Vector3 offsetPosition = new Vector3(-2f, 1.7f, -0.006847215f); //posizione iniziale camera
    //private Quaternion offsetRotation;// = new Vector3(15, 90, 0);

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offsetPosition;
        //transform.rotation = player.transform.rotation;// * offsetRotation;// * Quaternion.Euler(offsetRotation);
    }
}