using System.Collections;
using System.Collections.Generic;
using LeonBrave.GameManager;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace LeonBrave
{
	public class CanvasController : MonoBehaviour
	{
		public static CanvasController Instance;
	
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

			_myAnimator = transform.GetComponent<Animator>();

			UpdateHighScore();
		}

		public void UpdateHighScore()
		{
					
			foreach (TextMeshProUGUI highScore in _highScores)
			{
				highScore.text = "High Score : " + SaveManager.SaveManager.Instance.GameSaveState.HighScore;
			}

		}

		private Animator _myAnimator;

		[SerializeField]
		private List<TextMeshProUGUI> _highScores;

		[SerializeField] private List<TextMeshProUGUI> _scoreTexts;
		public void StartGameButtonDown()
		{
			GameManager.GameManager.Instance.StartGame();
		}

		public void SetTrigger(string trigger)
		{
			_myAnimator.SetTrigger(trigger);
		}

		public void UpdateScore(int score)
		{
			foreach (var scoreText in _scoreTexts)
			{
				scoreText.text = "" + score;
			}
		}

		public void RetryButtonDown()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

}
     
