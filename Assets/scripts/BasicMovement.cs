using UnityEngine;
using System.Collections;
using System;
public enum MovementMode { LOOK, FORWARD, STRAIGHT_FALL, SPIRAL_FALL }

public class BasicMovement : MonoBehaviour{

    // Use this for initialization
    void Start () {
        self = transform;
        myCamera = Camera.main;
        switch(movementMode)
        {
            case MovementMode.LOOK:
            case MovementMode.FORWARD:
                moveDirection = self.InverseTransformDirection(myCamera.transform.forward);
                break;
            case MovementMode.SPIRAL_FALL:
                moveDirection = new Vector3(radius * Mathf.Sin(Time.time), -1 * speed, radius * Mathf.Cos(Time.time));
                break;
            case MovementMode.STRAIGHT_FALL:
                moveDirection = Vector3.down * speed;
                break;
        }
        moveDirection.Normalize();
    }
    ///Transfrom caching
    private Transform self;
    
    /// <summary>
    ///The camera reference. used to get the move direction in camera movement related modes movement mode 
    /// </summary>
    [SerializeField]
    private Camera myCamera;

    /// <summary>
    ///  The movement speed, usually describes the forward(or in general the active move direction)
    ///  movement of the object
    /// </summary>
    [SerializeField]
    private float speed;

    public float Speed { get { return speed; } set { speed = value; } }
    public static float GeneralSpeed = 3.5f;
    /// <summary>
    /// DEscribes the active moving direction.
    /// </summary>
    [SerializeField]
    private Vector3 moveDirection;

    /// <summary>
    /// Defines the current used movement calculation method
    /// </summary>
    [SerializeField]
    private MovementMode movementMode;

    public MovementMode mode
    {
        set {
            movementMode = value;
            switch (movementMode)
            {
                case MovementMode.LOOK:
                case MovementMode.FORWARD:
                    moveDirection = self.InverseTransformDirection(myCamera.transform.forward);
                    break;
                case MovementMode.SPIRAL_FALL:
                    moveDirection = new Vector3(radius * Mathf.Sin(Time.time), -1 * speed, radius * Mathf.Cos(Time.time));
                    break;
                case MovementMode.STRAIGHT_FALL:
                    moveDirection = Vector3.down * speed;
                    break;
            }
            moveDirection.Normalize();
        }
        get { return movementMode; }
    }

    /// <summary>
    /// Defines the radius of the spiral fall movement
    /// </summary>
    [SerializeField]
    private float radius;

    // Update is called once per frame
    void Update () {
        switch (movementMode)
        {
            case MovementMode.LOOK:
                MoveByLook();
                break;
            case MovementMode.FORWARD:
                MoveForward();
                break;
            case MovementMode.SPIRAL_FALL:
                FallSpirally();
                break;
            case MovementMode.STRAIGHT_FALL:
                Fall();
                break;
        }
	}

    private void Fall()
    {
        self.position += moveDirection * speed * Time.deltaTime;
    }

    private void FallSpirally()
    {
        self.position += moveDirection * speed * Time.deltaTime;
        moveDirection = new Vector3(radius * Mathf.Sin(Time.time), -1 * speed, radius * Mathf.Cos(Time.time)).normalized;
    }

    private void MoveForward()
    {
        self.position += moveDirection * speed * Time.deltaTime;
    }

    private void MoveByLook()
    {
        self.Translate(Vector3.forward*speed*Time.deltaTime);
    }
    void DisableAnimations()
    {//Disables the animator component and starts the move
        this.enabled = true;
        GetComponent<Animator>().enabled = false;
    }

}
