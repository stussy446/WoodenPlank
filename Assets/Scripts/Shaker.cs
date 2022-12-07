using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [Header("Shake Settings")]
    [SerializeField] private float _shakeTime = 2f;
    [SerializeField] private float _shakeSpeed = 1f;
    [SerializeField] private float _shakeAmount = 1f;


    public void StartShaking()
    {
        Debug.Log($"{gameObject.name} is going to shake now!");
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float timer = _shakeTime;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        
        yield return null; 
    }
}
