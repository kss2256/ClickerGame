using System.Collections.Generic;
using UnityEngine;



public class SoundManager
{

    AudioSource[] mAudioSources = new AudioSource[(int)Define.eSoundType.MAXCOUNT];

    Dictionary<string, AudioClip> mAudioClipMap = new Dictionary<string, AudioClip>();

    public void Init()
    {                
        GameObject root = Util.GetOrAddGameObject("@Sound", true);


        string[] soundNames = System.Enum.GetNames(typeof(Define.eSoundType));

        for (int i = 0; i < soundNames.Length - 1; i++)
        {
            GameObject go = new GameObject { name = soundNames[i] };
            mAudioSources[i] = go.AddComponent<AudioSource>();
            go.transform.parent = root.transform;
        }

        mAudioSources[(int)Define.eSoundType.BGM].loop = true;
    }

    public void Play(string _fileName, Define.eSoundType _type = Define.eSoundType.EFFECT
      , float _pitch = 1.0f)
    {

        if (_type == Define.eSoundType.BGM)
        {
            AudioClip audioclip = GetorAddAudioClip(_fileName);

            AudioSource audiosource = mAudioSources[(int)Define.eSoundType.BGM];

            if (audiosource.isPlaying)
                audiosource.Stop();

            audiosource.pitch = _pitch;
            audiosource.clip = audioclip;
            audiosource.Play();


        }
        else
        {
            AudioClip audioclip = GetorAddAudioClip(_fileName);

            AudioSource audiosource = mAudioSources[(int)Define.eSoundType.EFFECT];
            audiosource.pitch = _pitch;
            audiosource.PlayOneShot(audioclip);

        }

    }


    public AudioClip GetorAddAudioClip(string _filename)
    {
        AudioClip Audio = null;

        if (mAudioClipMap.TryGetValue(_filename, out Audio) == false)
            Audio = GetAudioClip(_filename);

        return Audio;

    }


    public AudioClip GetAudioClip(string _filename)
    {

        string path = "Sounds/" + _filename;

        AudioClip audioclip = Managers.Resource.Load<AudioClip>(path);
        if (audioclip == null)
        {
            Debug.Log($"AudioClip Missing {path}");
            return null;
        }

        mAudioClipMap.Add(_filename, audioclip);

        return audioclip;
    }


    public void Clear()
    {

        foreach (AudioSource source in mAudioSources)
        {
            source.Stop();
            source.clip = null;
        }

        mAudioClipMap.Clear();
    }

}