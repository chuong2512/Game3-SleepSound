using System;
using SingleApp;
using UnityEngine;

[DefaultExecutionOrder(-99)]
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource musicSource;
    public float _timePlay = 0.6f;

    private AudioClip _audioClip;
    private float _timeCount;
    private bool _isPlaying;
    private int _crtId = -1;

    public void SetTimeCount(float time)
    {
        _timeCount = time;
    }

    private void Start()
    {
        _isPlaying = false;
        _crtId = GameDataManager.Instance.currentID;

        var currentSong = GameDataManager.Instance.songSo.GetSongWithID(_crtId);

        if (currentSong != null)
        {
            _audioClip = currentSong.song;
        }

        musicSource.loop = true;
    }

    /*private void FixedUpdate()
    {
        if (_isPlaying)
        {
            if (_timeCount > 0) _timeCount -= Time.fixedDeltaTime;
            else
            {
                musicSource.Stop();
                _isPlaying = false;
            }
        }
    }*/

    public void PlaySong(int id)
    {
        GameDataManager.Instance.SetCurrentSongID(id);

        _crtId = id;
        _audioClip = GameDataManager.Instance.songSo.GetSongWithID(_crtId).song;
        musicSource.clip = _audioClip;
        musicSource.Play();
        _isPlaying = true;
        _timeCount = _timePlay;
        GameManager.OnPlayMusic.Invoke(_isPlaying);
    }

    public void ClickPlayBtn()
    {
        if (!_isPlaying)
        {
            musicSource.Play();
        }
        else
        {
            musicSource.Stop();
        }

        _isPlaying = !_isPlaying;

        GameManager.OnPlayMusic.Invoke(_isPlaying);
        Debug.Log($"PLaying : {_isPlaying}");
    }
}