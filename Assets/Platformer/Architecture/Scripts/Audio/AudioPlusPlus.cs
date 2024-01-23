using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlusPlus : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;

    public void PlayRandomAudio()
    {
        _audioSource.clip = _audioClips[Random.Range(0, _audioClips.Length)];
        _audioSource.Play();
    }

    private void OnValidate()
    {
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }
}
