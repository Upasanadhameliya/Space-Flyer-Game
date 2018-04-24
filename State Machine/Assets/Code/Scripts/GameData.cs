using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    public Texture2D beginStateSplash;
    public Texture2D wonStateSplash;
    public Texture2D lostStateSplash;

    public List<GameObject> cameras;

    private int playerLivesSelected;
    private int sceneBeginningScore;

    [HideInInspector]
    public int playerLives;
    [HideInInspector]
    public int score;

    void Start () {
        playerLives = playerLivesSelected;
        score = sceneBeginningScore;
	}

    public void SetPlayerLives(int livesSelected)
    {
        playerLives = livesSelected;
        playerLivesSelected = livesSelected;
    }

    public void ResetPlayer()
    {
        playerLives = playerLivesSelected;
        score = sceneBeginningScore;
    }

    public void SetScore()
    {
        sceneBeginningScore = score;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
