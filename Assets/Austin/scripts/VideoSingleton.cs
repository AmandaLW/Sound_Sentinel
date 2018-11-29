using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//singleton pattern used to pass informatioin between scenes because the singleton won't be destroyed
public class VideoSingleton : Singleton<VideoSingleton> {

    // Prevent non-singleton constructor use.
    protected VideoSingleton() { }

    public string VideoString = "random";

}
