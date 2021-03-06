using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update

    public KeyCode tombolAtas = KeyCode.W;
    public KeyCode tombolBawah = KeyCode.S;

    public float speed = 10.0f;
    public float yBoundary = 9.0f;
    
    public int score;
    private Rigidbody2D rigidBody2D;
    
    private ContactPoint2D lastContactPoint;


    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rigidBody2D.velocity;

        if (Input.GetKey(tombolAtas)){
            velocity.y = speed;
        }

        else if(Input.GetKey(tombolBawah)){
            velocity.y = -speed;
        }

        else{
            velocity.y = 0.0f;
        }

        rigidBody2D.velocity = velocity;

//-----------------------------------------------------------

        Vector3 position = transform.position;

        if(position.y > yBoundary)
        {
            position.y = yBoundary;
        }

        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name.Equals("Ball")){
            lastContactPoint = collision.GetContact(0);
        }
    }

    public void IncrementScore(){
        score++;
    }

    public void ResetScore(){
        score = 0;
    }

    public int Score{
        get { return score; }
    }

    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }
}