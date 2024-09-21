using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoChanger : MonoBehaviour
{
    private VideoPlayer video;
    public List<string> videos;
    public VideoClip videoToPlay1;
    public VideoClip videoToPlay2;
    public GameObject sphere1;
    public GameObject sphere2;

    private LookAtInVR lookAtInVr;
    public GameObject Environment;

    // Start is called before the first frame update
    void Start()
    {

        sphere1.GetComponent<VideoPlayer>().Prepare();
        sphere2.GetComponent<VideoPlayer>().Prepare();

        sphere1.GetComponent<VideoPlayer>().prepareCompleted += VideoChanger_prepareCompleted;
       
        lookAtInVr = Environment.GetComponent<LookAtInVR>();
        lookAtInVr.ThresholdReached += LookAtInVr_ThresholdReached;

    }

    private void VideoChanger_prepareCompleted(VideoPlayer source)
    {
        source.Play();
    }

    private void LookAtInVr_ThresholdReached(object sender, ThresholdReachedEventArgs e)
    {
        print(e);
        sphere2.transform.position = new Vector3(0, 0, 0);
        sphere1.transform.position = new Vector3(0, 0, 10);
        sphere1.GetComponent<VideoPlayer>().Stop();
        sphere2.GetComponent<VideoPlayer>().Play();
    }

    
}