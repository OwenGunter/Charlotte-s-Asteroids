using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public int EnemyShipSpeed;

    // A reference to the player - this will be set when the enemy is loaded
    private GameObject m_Player;

    // A reference to the nav mesh agent component
    private NavMeshAgent m_NavAgent;

    // A reference to the rigidbody component
    private Rigidbody m_Rigidbody;

    private void Awake ()
    {
        m_Player = GameObject.FindGameObjectWithTag ("Player");
        m_NavAgent = GetComponent<NavMeshAgent> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
    }

    private void OnEnable ()
    {
        // when the ship is turned on, make sure it is not kinematic
        m_Rigidbody.isKinematic = false;
    }
}
