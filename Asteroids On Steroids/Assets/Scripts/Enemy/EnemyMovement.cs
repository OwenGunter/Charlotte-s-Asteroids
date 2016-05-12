using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public float m_Speed = 5f;

    // A reference to the player - this will be set when the enemy is loaded
    private GameObject m_Player;

    // A reference to the nav mesh agent component
    private NavMeshAgent m_NavAgent;

    // A reference to the rigidbody component
    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()

    {
        MoveUp();
    }

    private void MoveUp()

    {
        // create a vector in the direction the ship is facing with a magnitude
        // based on the input, speed and time between frames
        Vector3 movement = transform.forward * m_Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }




    private void OnEnable()
    {
        // when the ship is turned on, make sure it is not kinematic
        m_Rigidbody.isKinematic = false;
    }
}
