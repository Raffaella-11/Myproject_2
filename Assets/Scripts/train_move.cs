using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

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

    //confronta variabile vector3 evitando errori di approssimazione
    public bool V3Equal(Vector3 a, Vector3 b)
    {
        return Vector3.SqrMagnitude(a - b) < 0.0001;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) & startTrain == 0) //impedisce input mentre il treno si muove
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
        }

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
}