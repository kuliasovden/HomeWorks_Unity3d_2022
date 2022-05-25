using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SFXType
{
    ButtonClick,
    JumpSound,
    PlayerShootSound,
    EnemyShootSound,
    EnemyDeathSound,
    LevelComplitSound
}

public enum MusicType
{
    Game
}
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _musicSource;

    [SerializeField] private List<SFXData> _sfxDatas = new List<SFXData>();
    [SerializeField] private List<MusicData> _musicDatas = new List<MusicData>();

    private static SoundManager _instance;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void PlayMusicInner(MusicType musicType)
    {
        var musicData = _musicDatas.Find(data => data.Type == musicType);
        if (musicData != null)
        {
            _musicSource.clip = musicData.Music;
            _musicSource.Play();
        }
    }

    private void PlaySFXInner(SFXType sfx)
    {
        var sfxData = _sfxDatas.Find(data => data.SFX == sfx);
        if(sfxData != null)
        {
            _sfxSource.PlayOneShot(sfxData.Audio);
        }
    }

    public static void PlaySFX(SFXType sfx)
    {
        _instance.PlaySFXInner(sfx);
    }

    public static void PlayMusic(MusicType music)
    {
        _instance.PlayMusicInner(music);
    }

}
[System.Serializable]
public class SFXData
{
    [SerializeField]private SFXType _sfx;
    [SerializeField] private AudioClip _audioClip;

    public SFXType SFX => _sfx;
    public AudioClip Audio => _audioClip;
}
[System.Serializable]
public class MusicData
{
    [SerializeField] private MusicType _musicType;
    [SerializeField] private AudioClip _musicClip;

    public MusicType Type => _musicType;
    public AudioClip Music => _musicClip;
}