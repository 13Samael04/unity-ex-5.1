using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private int _time = 10;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.volume = _minVolume;
    }

    public void ChangeSignal(bool isEnter)
    {
        float targetVolume;

        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        if (isEnter == true)
        {
            targetVolume = _maxVolume;
        }
        else
        {
            targetVolume = _minVolume;
        }

        _coroutine = StartCoroutine(ChangeVolume(targetVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        var waitForSeconds = new WaitForSeconds(0.5f);
        float scale = _maxVolume / _time;

        if (_audioSource.volume <= _minVolume)
        {
            _audioSource.Play();
        }

        while(_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, scale);

            if (_audioSource.volume <= _minVolume)
            {
                _audioSource.Stop();
            }

            yield return waitForSeconds;
        }
    }
}
