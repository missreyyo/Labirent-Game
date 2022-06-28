using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public UnityEngine.UI.Text time,Right,Situation;
    private Rigidbody Rigidbody;
    public float speed = 1.5f;
    float timeCounter=60;
    int healthCounter=6;
    bool gameNext = true;
    bool gameFinished = false;
    // Start is called before the first frame update
    void Start()
    {
       Rigidbody = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameNext && !gameFinished){
        timeCounter = timeCounter - Time.deltaTime;
        time.text=(int)timeCounter+"";
        }
        else if(!gameFinished){
            Situation.text="Game over!";
        }
        if(timeCounter<0){
            gameNext=false;
        }
       
    }
    void FixedUpdate(){
        if(gameNext){
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(horizontalMove,0,verticalMove);
        Rigidbody.AddForce(force*speed);
        }
        else{
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.angularVelocity =Vector3.zero;
        }
    }
    void OnCollisionEnter(Collision Collision){
        string objName =Collision.gameObject.name;
        if(objName.Equals("Finish")){
            gameFinished= true;
            Situation.text="Game finished! Perfect!";
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.angularVelocity =Vector3.zero;

        }
        else if(!objName.Equals("Plane") && !objName.Equals("Plane2")){
            healthCounter -=1;
            Right.text=(int)healthCounter+"";
            if(healthCounter==0){
                gameNext=false;
            }
        }
    }
}
