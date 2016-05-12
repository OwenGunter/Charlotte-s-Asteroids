using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour

{

    public float m_Speed = 12f; // Controls the speed of the ship


    private Rigidbody m_Rigidbody;
    private float MoveVertical; // The current value of the Vertical input
    private float MoveHorizontal; // The current value of the Horizontal input

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        // when the tank is on make sure it is not kinematic
        m_Rigidbody.isKinematic = false;

        // also reset the input values
        MoveVertical = 0f;
        MoveHorizontal = 0f;
    }

    private void OnDisable()
    {
        // when the tank is off make sure it is kinematic.
        m_Rigidbody.isKinematic = true;
    }

    private void Update()
    {//this function checks the value of this input every frame and stores the value in the member variables for us to use later

        MoveVertical = Input.GetAxis("Vertical");
        MoveHorizontal = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()

    {
        MoveUp();
        MoveSideways();
    }

    private void MoveUp()

    {
        // create a vector in the direction the ship is facing with a magnitude
        // based on the input, speed and time between frames
        Vector3 movement = transform.forward * MoveVertical * m_Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void MoveSideways()

    {
        Vector3 movement = transform.right * MoveHorizontal * m_Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }
}

    


