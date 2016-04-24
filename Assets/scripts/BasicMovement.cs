using UnityEngine;
using System.Collections;
using System;

public class BasicMovement : MonoBehaviour {

    enum MovementMode { LOOK, FORWARD}
    // Use this for initialization
    void Start () {
        self = transform;
        camera = Camera.main;
        moveDirection = self.InverseTransformDirection(camera.transform.forward);
        moveDirection.Normalize();
    }
    ///Transfrom caching
    private Transform self;
    
    /// <summary>
    ///The camera reference. used to get the move direction in camera movement related modes movement mode 
    /// </summary>
    [SerializeField]
    private Camera camera;

    /// <summary>
    ///  The movement speed, usually describes the forward(or in general the active move direction)
    ///  movement of the object
    /// </summary>
    [SerializeField]
    private float speed;
   
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
        }
	}

    private void MoveForward()
    {
        self.position += moveDirection * speed * Time.deltaTime;
    }

    private void MoveByLook()
    {
        self.Translate(Vector3.forward*speed*Time.deltaTime);
    }
}
