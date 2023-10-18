using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace LeonBrave.CubeObjects
{
    public class CubeObject : MonoBehaviour
    {
        [SerializeField] private CubeObjectData _properties;

        private float _blowTimer = 0f;

        [SerializeField]
        private bool _isGround;

        private void OnEnable()
        {
            _properties.CubeObjectState = CubeObjectState.InGame;
            _blowTimer = 0;
        }

        private void GotoNewPos()
        {
            if (_isGround)
            {
                gameObject.SetActive(false);
            }
            _blowTimer = 0;
            _properties.CubeObjectState = CubeObjectState.InGame;
            CubeHandler.CubeHandler.Instance.AddCube(gameObject);
      
        }

        private void Update()
        {
            if (_properties.CubeObjectState != CubeObjectState.PoolTime)
            {
                return;
            }

            _blowTimer += Time.deltaTime;
            if (_blowTimer >= _properties.BlowTime)
            {
                GotoNewPos();
            }
        }

        private void FixedUpdate()
        {
            if (_properties.CubeObjectState != CubeObjectState.PoolTime) return;

            transform.position += Vector3.down * _properties.DownSpeed * Time.fixedDeltaTime;
        }

        private void OnCollisionExit(Collision collision)
        {
            if (_properties.CubeObjectState != CubeObjectState.InGame) return;

            if (collision.gameObject.CompareTag("Player"))
            {
                _properties.CubeObjectState = CubeObjectState.PoolTime;
            }
        }
    }
}