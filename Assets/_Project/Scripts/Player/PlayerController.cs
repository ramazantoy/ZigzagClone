using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeonBrave.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerControllerData _properties;

        private float _currentXDirection = 1;


        private void Start()
        {
            UserInput.UserInput.Instance.TouchDown += ChangeDirection;
        }

        private void ChangeDirection()
        {
            _currentXDirection *= -1;
        }

        private void FixedUpdate()
        {
            Vector3 moveDirection = new Vector3(_currentXDirection, 0, 1);
            Vector3 newPosition =
                transform.position + (moveDirection * Time.fixedDeltaTime * _properties.MovementSpeed);
            _properties.PlayerRigidBody.MovePosition(newPosition);
        }
    }
}