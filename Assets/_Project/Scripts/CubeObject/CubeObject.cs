using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeonBrave.CubeObjects
{
    public class CubeObject : MonoBehaviour
    {
        [SerializeField]
        private CubeObjectData _properties;

        private float _poolTimer = 0f;

        private void OnEnable()
        {
            _poolTimer = 0f;
        }

        private void Update()
        {
            if(_properties.CubeObjectState!=CubeObjectState.PoolTime) return;
            
            
        }
    }

}
