using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deadtriggercontroller : MonoBehaviour {

public GameObject player;
public bool playerDead;
public GameObject gameManager;

void Start() {
	playerDead = false;
	gameManager =  GameObject.FindGameObjectWithTag("gameManager");
	
}

void Update()
{
	if(playerDead)
	{
		playerDead = false;
	}
}
void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag == "DeadTrigger")
		{
			gameManager.GetComponent<GameController>().playerDead = true;
			Destroy(player);
		}
		if(other.tag == "FirstKiller")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
	
}
