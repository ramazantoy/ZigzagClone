using System.Collections;
using System.Collections.Generic;
using LeonBrave.GameManager;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _followSpeed = 5.0f;

    private float zOffset;

    private void Start()
    {
        zOffset = transform.position.z - _targetTransform.position.z;
    }

    private void FixedUpdate()
    {
        if(GameManager.Instance.GameState!=GameState.Playing) return;
        
        float targetZPosition = _targetTransform.position.z + zOffset;

        Vector3 newPosition = transform.position;
        newPosition.z = Mathf.Lerp(transform.position.z, targetZPosition, _followSpeed * Time.fixedDeltaTime);
        transform.position = newPosition;
    }
}