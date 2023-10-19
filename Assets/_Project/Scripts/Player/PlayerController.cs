using System;
using System.Collections;
using System.Collections.Generic;
using LeonBrave.GameManager;
using UnityEngine;

namespace LeonBrave.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerControllerData _properties;

        private float _currentXDirection = 1;

        private int _currentScore = 0;

        private void Start()
        {
            UserInput.UserInput.Instance.TouchDown += ChangeDirection;
        }

        private void ChangeDirection()
        {
            _currentXDirection *= -1;
            _currentScore++;
            CanvasController.Instance.UpdateScore(_currentScore);

            int highScore = SaveManager.SaveManager.Instance.GameSaveState.HighScore;

            if (_currentScore > highScore)
            {
                SaveManager.SaveManager.Instance.GameSaveState.HighScore = _currentScore;
                CanvasController.Instance.UpdateHighScore();
            }
        }

        public void CurrentScoreUp(int score)
        {
            _currentScore += score;
            
            int highScore = SaveManager.SaveManager.Instance.GameSaveState.HighScore;

            if (_currentScore > highScore)
            {
                SaveManager.SaveManager.Instance.GameSaveState.HighScore = _currentScore;
                CanvasController.Instance.UpdateHighScore();
            }
        }
        private void FixedUpdate()
        {
            if(GameManager.GameManager.Instance.GameState!=GameState.Playing) return;

            if (transform.position.y < 0)
            {
                GameManager.GameManager.Instance.UpdateGameState(GameState.Lose);
                return;
            }
            
            Vector3 moveDirection = new Vector3(_currentXDirection, 0, 1);
            Vector3 newPosition =
                transform.position + (moveDirection * Time.fixedDeltaTime * _properties.MovementSpeed);
            _properties.PlayerRigidBody.MovePosition(newPosition);
        }
    }
}