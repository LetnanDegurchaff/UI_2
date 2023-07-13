using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthVeiwChenger : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private Slider _slider;
    private float _speed;

    private Coroutine _coroutine;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        _slider.value = _player.Health;
        _speed = 0.25f;
    }

    private void OnEnable()
    {
        _player.HealthChanged += UpdateHealth;
        _coroutine = null;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= UpdateHealth;
        _coroutine = null;
    }

    private void UpdateHealth(int health)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Run(health));
    }

    private IEnumerator Run(float target)
    {
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        float startPosition = _slider.value;

        float elapsedTime = 0.00001f;
        float duration;

        duration = 1 / _speed;

        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards
                (_slider.value, target, elapsedTime / duration);

            elapsedTime += Time.deltaTime;

            yield return waitForEndOfFrame;
        }
    }
}