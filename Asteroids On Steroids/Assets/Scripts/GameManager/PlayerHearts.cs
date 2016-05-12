using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHearts : MonoBehaviour {

	//amount of hearts the player starts with
	public float m_StartingHearts = 3f;

	public float amount = 1f;

	public GameObject[] m_Hearts;


	private float m_CurrentHearts;
	private bool m_Dead;

	private void OnEnable()
	{
		// reset ship health to starting health and it is not dead
		m_CurrentHearts = m_StartingHearts;
		m_Dead = false;
    }

	private void SetHealthUI () {

		if (m_Hearts [0].activeSelf) {
			m_Hearts [0].SetActive (false); 
		} else if (m_Hearts [1].activeSelf) {
			m_Hearts [1].SetActive (false);
		}
		else {
			m_Hearts [2].SetActive (false);
		}
	}

	public void TakeDamage(float amount)
	{
		// Reduce current health by one 
		m_CurrentHearts -= amount;
		// Change the UI elements appropriately
		SetHealthUI();
		// if the current health is at or below zero and it has not yet
		// been registered, call OnDeath
		if (m_CurrentHearts<= 0f && !m_Dead)
		{
			OnDeath();
            Debug.Log (m_CurrentHearts);
		}
	}

	private void OnDeath()
	{
		// Set the flag so that this function is only called once
		m_Dead = true;

		Debug.Log (m_Dead);

		gameObject.SetActive(false); 

	}
	//Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}
}

