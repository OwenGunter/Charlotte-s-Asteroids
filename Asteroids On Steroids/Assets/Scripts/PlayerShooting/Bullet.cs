using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
public float m_MaxLifeTime = 3f;

public float m_MaxDamage = 1;

public float m_ExplosionRadius = 5;


    private void Start()
{
    Destroy(gameObject, m_MaxLifeTime);
}

private void OnCollisionEnter(Collision other)

{
    // find the rigidbody of the collision object
    Rigidbody targetRigidbody = other.gameObject.GetComponent<Rigidbody>();


    if (targetRigidbody != null)
    {
            // Add an explosion force
            // targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
            
                PlayerHearts targetHealth = targetRigidbody.GetComponent<PlayerHearts>();

                EnemyHearts m_targetHealth = targetRigidbody.GetComponent<EnemyHearts>();
            
            if (targetHealth != null)
        {
           
           float damage = m_MaxDamage;

            // Deal this damage to the tank
           targetHealth.TakeDamage(damage);

        }
            if(m_targetHealth != null)
            {
                float damage = m_MaxDamage;

               m_targetHealth.TakeDamage(damage);
            }
    }
}

    public void TakeDamage(float amount)
    {
        // Reduce current health by one 
        m_MaxDamage -= amount;

        Debug.Log(m_MaxDamage);
    }
   

    /*private float CalculateDamage(Vector3 targetPosition)
    {
        // Create a vector from the shell to the target
        Vector3 explosionToTarget = targetPosition - transform.position;
        // Calculate the distance from the shell to the target
        float explosionDistance = explosionToTarget.magnitude;
        // Calculate the proportion of the maximum distance (the explosionRadius)
        // the target is away
        float relativeDistance =
            (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
        // Calculate damage as this proportion of the maximum possible damage
        float damage = relativeDistance * m_MaxDamage;
        // Make sure that the minimum damage is always 0
        damage = Mathf.Max(0f, damage);
        return damage;
    }*/
}