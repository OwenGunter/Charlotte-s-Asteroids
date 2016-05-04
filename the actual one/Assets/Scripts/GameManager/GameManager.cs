using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    //reference to player ship 
    public GameObject m_PlayerShip;

	//array of all ships
	public GameObject[] m_Ships;

    //reference to enemy ship
    public GameObject m_EnemyShip;

	//public Text m_ScoreText;

    //inital spawning point of player ship upon starting
    private Vector3 m_PlayerShipSpawn = new Vector3(0, 0, 0);

    //start = 0
    //playing = 1
    //gameover = 2
    public enum GameState
    {
        Start,
        Playing,
        GameOver
    };

    //reference to above gamestates
    private GameState m_GameState;

    private void Awake()
    {
        m_GameState = GameState.Start;
    }


    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_GameState)
        {

            case GameState.Start:
                //when enter/return is pressed
                //should change to button
                if (Input.GetKeyUp(KeyCode.Return) == true)
                {
                    //switch to playing gamestate
                    m_GameState = GameState.Playing;

                }
                break;
            case GameState.Playing:
                //if in this gamestate, the game is not over
                bool isGameOver = false;

                if (isGameOver = true)
                {
                    //gameover is gamestate gameover
                    m_GameState = GameState.GameOver;

                }
                break;
            case GameState.GameOver:
                //if return key is pressed start over 
                if (Input.GetKeyUp(KeyCode.Return) == true)
                {
                    m_GameState = GameState.Playing;

				for (int i = 0; i < m_Ships.Length; i++) {
					m_Ships [i].SetActive (true);
				}

                }
                break;
        }
        //if escape pressed at any time then quit 
        if (Input.GetKeyUp(KeyCode.Escape))
        {
			
            Application.Quit();
        }

    }
}
