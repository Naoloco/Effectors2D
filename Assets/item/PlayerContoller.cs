using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
    {
    Rigidbody2D playerRigidbody2D;
    bool pressJump;
    public float jumpPower;
    public float directionX;
    public float speed;

    void Start ( )
        {
        playerRigidbody2D = GetComponent<Rigidbody2D> ( );
        }
    
    void Update ( )
        {
        detectingJump ( );
        detectingWalk ( );
        }

    void detectingJump ( ) {
        if ( Input.GetKeyDown ( KeyCode.Space)||Input.GetKeyDown ( KeyCode.Joystick1Button0 )
            )
            {
            playerRigidbody2D.AddForce ( new Vector2 ( 0 , jumpPower ) );
            }
        }

    void detectingWalk ( ) {
        directionX = Input.GetAxis ( "Horizontal" );
        playerRigidbody2D.AddForce ( new Vector2 ( directionX * speed , 0 )  );
        }
    }
