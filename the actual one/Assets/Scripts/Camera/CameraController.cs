using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    // controls the speed the camera reacts to the movements of the player
    public float m_DampTime = 0.2f;
    // variable for the awake function
    public Transform m_target;
    // variables for the Move function
    private Vector3 m_MoveVelocity;
    private Vector3 m_DesiredPosition;

    private void Awake()
    { // finds gameobject with the Player tag when the script is initalized
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    // we use a fixed update function so that it updates more consistently
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    { // gets the position of the target object (the player) and smoothly move the camera from its current position to this target position
        m_DesiredPosition = m_target.position;
        // to achieve this we use the smoothdamp function which will return a position between the starting and ending position
        // The Damptime variable is used to control how quickly the camera reacts to the movements of the player
        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);

    }
}
