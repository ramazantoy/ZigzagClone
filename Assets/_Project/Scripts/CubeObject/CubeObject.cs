using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using LeonBrave.GameManager;
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
            GiveExtraPoint();
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
            GiveExtraPoint();
      
        }

        private void Update()
        {
            if(GameManager.GameManager.Instance.GameState!=GameState.Playing) return;
            
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
            if (_properties.CubeObjectState != CubeObjectState.InGame  || GameManager.GameManager.Instance.GameState!=GameState.Playing) return;

            if (collision.gameObject.CompareTag("Player"))
            {
                _properties.CubeObjectState = CubeObjectState.PoolTime;
                
                if (!_isGround)
                {
                    _properties.ExtraPointObject.SetActive(false);
                }
           
            }
        }

        private void GiveExtraPoint()
        {
            if(_isGround) return;
            
            int rate = UnityEngine.Random.Range(0, 101);
            if (rate < _properties.GiveExtraPointRate)
            {
                _properties.ExtraPointObject.SetActive(true);
            }
        }
    }
}