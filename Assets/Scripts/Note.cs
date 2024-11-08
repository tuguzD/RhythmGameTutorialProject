using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;
    void Start()
    {
        timeInstantiated = assignedTime - SongManager.Instance.noteTime;
    }

    // Update is called once per frame
    void Update()
    {
        float spawnDelay = SongManager.Instance.songDelayInSeconds - SongManager.Instance.noteTime;
        double timeSinceInstantiated = spawnDelay > 0 && timeInstantiated < 0
            ? (Time.timeSinceLevelLoad - spawnDelay) + timeInstantiated
            : SongManager.GetAudioSourceTime() - timeInstantiated;
        
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));
        
        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(Vector3.up * SongManager.Instance.noteSpawnY, Vector3.up * SongManager.Instance.noteDespawnY, t); 
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
