using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shaker : MonoBehaviour
{
    [Header("Shake Settings")]
    [SerializeField] private float _shakeTime = 2f;
    [SerializeField] private float _shakeAmount = 0.01f;

    private bool _isShaking = false;

    private void Update()
    {
        if (_isShaking)
        {
            float xPos = Random.Range(transform.position.x + _shakeAmount, transform.position.x - _shakeAmount);
            Vector3 newPos = new Vector3(xPos, transform.position.y, transform.position.z);

            transform.position = newPos;
        }
    }

    /// <summary>
    /// Calls Shake IEnumerator to allow shaking to occur on the gameobject
    /// </summary>
    public void StartShaking()
    {
        StartCoroutine(Shake());
    }

    /// <summary>
    /// Sets _isShaking to true and yields for _shakeTime seconds, allowing the object to shake for that amount of time before the object returns to its original position
    /// </summary>
    /// <returns></returns>
    private IEnumerator Shake()
    {
        Vector3 originalPos = transform.position;

        if (!_isShaking)
        {
            _isShaking = true;
        }

        yield return new WaitForSeconds(_shakeTime);

        _isShaking = false;
        transform.position = originalPos;
    }
}
