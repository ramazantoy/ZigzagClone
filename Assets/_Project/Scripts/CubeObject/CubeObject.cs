using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace LeonBrave.CubeObjects
{
    public class CubeObject : MonoBehaviour
    {
        [SerializeField]
        private CubeObjectData _properties;

        private float _blowTimer = 0f;
        private float _poolTimer = 0f;

        private void OnEnable()
        {
            _poolTimer = 0f;
        }

        private void GotoPool()
        {
            CubeObjectPool.Instance.AddObject(gameObject);
        }

        private void Update()
        {
            if (_properties.CubeObjectState == CubeObjectState.InGame)
            {
                _poolTimer += Time.deltaTime;
                if (_poolTimer >= _properties.PoolTime)
                {
                    _properties.CubeObjectState = CubeObjectState.PoolTime;
                }
            }
            else
            {
                _blowTimer += Time.deltaTime;
                if (_blowTimer >= _properties.BlowTime)
                {
                    GotoPool();
                }
            }
            
      
        }

        private void FixedUpdate()
        {
            if(_properties.CubeObjectState!=CubeObjectState.PoolTime) return;

            transform.position += Vector3.down * _properties.DownSpeed*Time.fixedDeltaTime;
       
        }
    }

}
