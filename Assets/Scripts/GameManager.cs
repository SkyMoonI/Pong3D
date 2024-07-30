using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;

	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<GameManager>();
				if (_instance == null)
				{
					Debug.LogError("GameManager instance not found!");
				}
			}
			return _instance;
		}
	}
	BotManagement botManager;


	public void LoadGameSceneTwoPlayer()
	{
		SceneManager.LoadScene("GameScene"); // Load scene by name
	}
	public void LoadGameSceneOnePlayer()
	{
		SceneManager.LoadScene("GameScene"); // Load scene by name
	}

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
}