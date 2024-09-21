using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresholdReachedEventArgs : EventArgs
{
    public int Threshold { get; set; }
    public DateTime TimeReached { get; set; }
}

public class LookAtInVR : MonoBehaviour
{
    // Start is called before the first frame update
    public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
    public Camera lookAtCamera;
    private Transform t;
    void Start()
    {              
        lookAtCamera = Camera.main;
        print(lookAtCamera);
    }

    // Update is called once per frame
    void Update()
    {
        print(lookAtCamera.transform.eulerAngles.y);
          if(lookAtCamera.transform.eulerAngles.y > 275 && lookAtCamera.transform.eulerAngles.y < 300)
          {
              print("change video");
              ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
              args.Threshold = 1;
              args.TimeReached = DateTime.Now;
              OnThresholdReached(args);
          }

    }

    protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
    {        
        if (ThresholdReached != null)
        {
            ThresholdReached(this, e);
        }
    }
}