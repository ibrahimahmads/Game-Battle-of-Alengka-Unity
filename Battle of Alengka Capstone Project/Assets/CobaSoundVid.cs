using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CobaSoundVid : MonoBehaviour
{
    VideoPlayer vid;
    // Start is called before the first frame update
    void Start()
    {
        vid = GetComponent<VideoPlayer>();
        vid.SetDirectAudioVolume(1, 0.5f);
        // set volume = playerpref.getfloat("musicVolume,vo
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
