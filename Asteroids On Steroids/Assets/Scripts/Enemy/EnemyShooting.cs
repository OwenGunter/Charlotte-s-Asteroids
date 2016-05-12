using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

    // Prefab of the Bullet
    public Rigidbody m_Bullet;

    // A child of the ship where the shells are spawned
    public Transform m_FireTransform;

    // The force given to the shell when firing
    public float m_LaunchForce = 30f;

    public float m_ShootDelay = 1f;

    public bool m_CanShoot;

    private float m_ShootTimer;

    public float m_BulletDamage;

    //private void Awake ()

    private void Update ()
    {
        if (m_CanShoot == true)
        {
            m_ShootTimer -= Time.deltaTime;
            if (m_ShootTimer <= 0)
            {
                m_ShootTimer = m_ShootDelay;
                Fire ();
            }
        }
    }

    private void Fire ()
    {
        // Create an instance of the Bullet and store a reference to it's rigidbody
        Rigidbody BulletInstance = Instantiate (m_Bullet, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Set the Bullet's velocity to the launch force in the fire position's
        // forward direction
        BulletInstance.velocity = m_LaunchForce * m_FireTransform.forward;
        Debug.Log(m_LaunchForce * m_FireTransform.forward);
    }
}
