using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public string ResourceDir = "";

    protected override void Awake()
    {
        base.Awake();

        _bgAudioSource = this.gameObject.AddComponent<AudioSource>();
        _bgAudioSource.playOnAwake = false;
        _bgAudioSource.loop = true;

        _effectAudioSource = this.gameObject.AddComponent<AudioSource>();
    }

    AudioSource _bgAudioSource;
    AudioSource _effectAudioSource;

    //设置声音大小
    public float SetBGVolume
    {
        set { _bgAudioSource.volume = value; }
    }

    //设置音效大小
    public float SetEffectVolume
    {
        set { _effectAudioSource.volume = value; }
    }

    //播放背景声音
    public void PlayBGSound(string audioName)
    {
        string oldName = "";
        if (_bgAudioSource.clip != null)
        {
            oldName = _bgAudioSource.clip.name;
        }
        if (oldName == audioName)
            return;

        string path = GetPath(audioName);

        AudioClip clip = Resources.Load<AudioClip>(path);
        if (clip != null)
        {
            _bgAudioSource.clip = clip;
            _bgAudioSource.Play();
        }
    }
    //停止背景声音
    public void StopBg()
    {
        _bgAudioSource.Stop();
        _bgAudioSource.clip = null;
    }
    //播放特效声音
    public void PlayEffectSound(string audioName)
    {
        string path = GetPath(audioName);
        AudioClip clip = Resources.Load<AudioClip>(path);
        if (clip != null)
        {
            _effectAudioSource.PlayOneShot(clip);
        }
    }
    //停止特效声音
    public void StopEffect()
    {
        _effectAudioSource.Stop();
        _effectAudioSource.clip = null;
    }

    string GetPath(string audioName)
    {
        string path = "";
        if (string.IsNullOrEmpty(ResourceDir))
            path = audioName;
        else
            path = ResourceDir + "/" + audioName;

        return path;
    }
}
