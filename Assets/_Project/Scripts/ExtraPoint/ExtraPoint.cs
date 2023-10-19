using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
     
public class ExtraPoint : MonoBehaviour
{


    private TextMeshPro _textMeshPro;
    
    [SerializeField]
    private float _moveSpeed = 3f;

    [SerializeField]
    private float _poolTime=3f;

    private float _poolTimer = 0f;
    

    private void Awake()
    {
        _textMeshPro = transform.GetChild(0).GetComponent<TextMeshPro>();
    }

    private void OnEnable()
    {
        _poolTimer = 0f;
    }

    public void SetExtraPoint(Vector3 bornPos, int extraPoint)
    {
        transform.position = bornPos;
        _textMeshPro.text = "+" + extraPoint;
    }

    private void Update()
    {
        if (_poolTimer >= _poolTime)
        {
            ExtraPointPool.Instance.AddObject(this);
            return;
        }

        _poolTimer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.up * _moveSpeed * Time.fixedDeltaTime;
    }
}
