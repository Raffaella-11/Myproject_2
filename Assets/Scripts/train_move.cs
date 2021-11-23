using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.WSA;

public class train_move : MonoBehaviour
{
    public PathCreator pathCreator; //path che il treno seguirà
    
    //dichiaro variabili a cui associo i 2 path diversi
    public GameObject pathLeftObj; 
    public GameObject pathRightObj;
    
    public float speed = 3;
    private float distanceTravelled;
    public EndOfPathInstruction end;
    
    private Vector3 startPosition = new Vector3(0.4f, 0, 0); //posizione iniziale trenino
    private int startTrain = 0; //serve come variabile flag per evitare che il treno parta prima di aver scelto uno dei due path
    private Quaternion offset; //per sistemare la rotazione del trenino lungo il path
    
    public bool V3Equal(Vector3 a, Vector3 b) //confronta variabile vector3 evitando errori di approssimazione
    {
        return Vector3.SqrMagnitude(a - b) < 0.001;
    }
    
    //variabili per input stile swipe di tinder
    //private bool tap, swipeLeft, swipeRight;
    private Vector2 startTouch, swipeDelta;
    private bool isDraging = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //tap = swipeLeft = swipeRight = false;
        
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            //tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion
        /*#region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            tap = true;
            isDraging = true;
            startTouch = Input.touches[0].position;
        }
        else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
        {
            isDraging = false;
            Reset();
        }
        #endregion*/ //i mobile inputs danno errori
        
        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging & startTrain == 0) //impedisce input se treno in movimento
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2) Input.mousePosition - startTouch;
        }

        if (swipeDelta.magnitude > 125)
        {
            //which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)//swipe a sinistra
                {
                    //swipeLeft = true;
                    pathCreator = pathLeftObj.GetComponent<PathCreator>(); //cambia path
                    offset = pathCreator.path.GetRotation(1); //cambia offset
                    distanceTravelled = 0; //azzera la distanza
                    startTrain = 1; //entra nell'if di movimento del treno
                }
                else//swipe a destra
                {
                    //swipeRight = true;
                    pathCreator = pathRightObj.GetComponent<PathCreator>();
                    offset = pathCreator.path.GetRotation(1);
                    distanceTravelled = 0;
                    startTrain = 1;
                }
            }
            Reset();
        }
        
        //vecchia versione dei comandi tramite tastiera, usarli per test fururi o errori
        /*if (Input.GetKey(KeyCode.A) & startTrain == 0) //impedisce input mentre il treno si muove
        {
            pathCreator = pathLeftObj.GetComponent<PathCreator>(); //cambia path
            offset = pathCreator.path.GetRotation(1); //cambia offset
            
            distanceTravelled = 0; //azzera la distanza
            startTrain = 1; //entra nell'if di movimento del treno
        }
        if (Input.GetKey(KeyCode.D) & startTrain == 0)
        {
            pathCreator = pathRightObj.GetComponent<PathCreator>();
            offset = pathCreator.path.GetRotation(1);
            
            distanceTravelled = 0;
            startTrain = 1;
        }*/

        //movimento effettivo del treno
        if (startTrain == 1)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, end);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, end) * offset * offset;

            if (V3Equal(transform.position,startPosition))
            {
                startTrain = 0; //riattiva possibilità input del player
            }
        }
    }
    
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}