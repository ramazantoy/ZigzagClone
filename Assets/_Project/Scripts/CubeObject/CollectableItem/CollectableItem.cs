using System;
using System.Collections;
using System.Collections.Generic;
using LeonBrave.Player;
using UnityEngine;
     
public class CollectableItem : MonoBehaviour
{

    private Animator _animator;
    private void Awake()
    {
        _animator = transform.GetComponent<Animator>();
        _animator.Play("Rotation", 0, UnityEngine.Random.Range(0f, 1f));
    }
    [SerializeField]
    private int _givePointAmount = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController playerController))
        {
            playerController.CurrentScoreUp(_givePointAmount);
            ExtraPoint extraPoint = ExtraPointPool.Instance.TakeObject();
            extraPoint.SetExtraPoint(transform.position,_givePointAmount);
            gameObject.SetActive(false);
        }
    }
}
