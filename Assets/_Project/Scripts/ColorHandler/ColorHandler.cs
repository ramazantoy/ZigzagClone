using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace LeonBrave.ColorHandler
{
    public class ColorHandler : MonoBehaviour
    {
        [SerializeField]
        private ColorHandlerData _properties;


        private float _colorTimer = 0f;
        private float _targetColorTime;

        private void Awake()
        {
           SetTimer();
        }

        private void SetTimer()
        {
            _targetColorTime = _properties.UseRandomTime ? _properties.RandomTime.RandomValue : _properties.RegularTime;
        }

        private void ChangeColor()
        {
            ColorData colorDataTemp = _properties.GetRandomColorData();

            _properties.CubeMaterial.color = colorDataTemp.MainColor;
            _properties.CubeMaterial.SetColor("_EmissionColor",colorDataTemp.EmissionColor);

            if (_properties.UseRandomTime)
            {
                SetTimer();
            }
        }
        private void Update()
        {
            _colorTimer += Time.deltaTime;

            if (_colorTimer >= _targetColorTime)
            {
                _colorTimer = 0f;
                ChangeColor();
            }
        }
    }
}