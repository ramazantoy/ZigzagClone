using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeonBrave.GameManager
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager Instance;
	
		void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if(Instance != this)
			{
				Destroy(gameObject);
			}
		}

		private GameState _gameState = GameState.None;

		public GameState GameState
		{
			get
			{
				return _gameState;
			}
		}

		public void StartGame()
		{
			if(_gameState!=GameState.None) return;

			_gameState = GameState.Playing;
		}


		public void UpdateGameState(GameState gameState)
		{
			if(_gameState!=GameState.Playing) return;

			_gameState = gameState;

			if (_gameState == GameState.Lose)
			{
				
			}
		}

		public void ReloadLevel()
		{
			
		}
	}
}

