using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour
{
    public float m_MaxLifeTime = 3f;

    public float m_MaxDamage = 2;

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

        if (targetHealth != null)
        {
            // Calculate the amount of damage the target should take
            // based on it's distance from the laser.
            float damage = CalculateDamage(targetRigidbody.position);

            // Deal this damage to the tank
            targetHealth.TakeDamage(damage);

			}
		}
	}
	private float CalculateDamage(Vector3 targetPosition)
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
	}
}