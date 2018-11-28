using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSingleton : Singleton<VideoSingleton> {

    // Prevent non-singleton constructor use.
    protected VideoSingleton() { }

    public string VideoString = "random";

}
