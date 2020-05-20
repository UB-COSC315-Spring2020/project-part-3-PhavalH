using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    
    public float tapForce = 275; //upward force
    public float tiltSmooth = 10;
    public Vector2 startPos;
    public float pointValue;

    public GameOperator gameOperatorInstance;

    public ScoreScript scoreScriptInstance;
    public Animator motionLayer;
    
    Rigidbody2D rigidbody;

    
    //rotates Bird
    Quaternion downRotation;
    Quaternion forwardRotation;

    

    void Start()
    {
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rigidbody = GetComponent<Rigidbody2D>();

        //Returns a rotation that rotates z degrees around the z axis, 
        //x degrees around the x axis, and y degrees around the y axis;
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
        
    }

    void Update()
    {
        //applies movement to the player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = forwardRotation;
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);

    }

    //triggers dead zone & score zone
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Touched A Collider " + col.gameObject.tag);
        

        if (col.gameObject.CompareTag("Scorezone"))
        {
            scoreScriptInstance.pointValue += 5; //adds points when the player triggers the scorezone
        }

        if (col.gameObject.CompareTag("Deadzone"))
        {
            //Don't allow control if the bird has died.
            rigidbody.simulated = false;
            Debug.Log("Deadzone Touched");
            gameOperatorInstance.SetPageState(GameOperator.PageState.GameOver);  //refers to page state in game operator script
            motionLayer.enabled = false; //stops animation
            
        }

    }
}

     