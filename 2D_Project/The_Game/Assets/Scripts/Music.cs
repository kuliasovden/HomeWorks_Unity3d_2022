using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private MusicType _music;
    // Start is called before the first frame update
    void Start()
    {
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayMusic()
    {
        SoundManager.PlayMusic(_music);
    }

}
