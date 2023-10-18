using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using LeonBrave.CubeObjects;
using UnityEngine;

namespace LeonBrave.CubeHandler
{
    public class CubeHandler : MonoBehaviour
    {
        [SerializeField] private CubeHandlerData _properties;

        private Transform _lastObjectTransform;

        public static CubeHandler Instance;



        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            GameObject cubeTemp = CubeObjectPool.Instance.TakeObject();
            cubeTemp.transform.localPosition = _properties.StartPos;
            cubeTemp.transform.parent = transform;

            _lastObjectTransform = cubeTemp.transform;
            
            for (int i = 0; i < _properties.StartCubeCount; i++)
            {
                BuildCubeOnStart();
            }
        }

        private float _xOffset;

        private void BuildCubeOnStart()
        {
            GameObject cubeTemp;
            Vector3 offset;
            int random = UnityEngine.Random.Range(0, 2);
            VectorClamp vectorClamp;
            if (random == 0) //Right
            {
                offset = new Vector3(_properties.RightOffset.X, 0, _properties.RightOffset.Z);
            }
            else //Left
            {
                offset = new Vector3(_properties.LeftOffset.X, 0, _properties.LeftOffset.Z);
            }

            cubeTemp = CubeObjectPool.Instance.TakeObject();
            cubeTemp.transform.localPosition = _lastObjectTransform.localPosition + offset;
            cubeTemp.transform.parent = transform;
            _lastObjectTransform = cubeTemp.transform;
            _lastObjectTransform.ClampLocalPosition(_properties.CubePositionClamp);
        }

        public void AddCube(GameObject cubeTemp)
        {
            Vector3 offset;
            int random = UnityEngine.Random.Range(0, 2);
            VectorClamp vectorClamp;
            if (random == 0) //Right
            {
                offset = new Vector3(_properties.RightOffset.X, 0, _properties.RightOffset.Z);
            }
            else //Left
            {
                offset = new Vector3(_properties.LeftOffset.X, 0, _properties.LeftOffset.Z);
            }
            
            cubeTemp.transform.localPosition = _lastObjectTransform.localPosition + offset;
            cubeTemp.transform.parent = transform;
            _lastObjectTransform = cubeTemp.transform;
            _lastObjectTransform.ClampLocalPosition(_properties.CubePositionClamp);
        }
    }
}