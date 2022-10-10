using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AiAgent agent;
 
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<AiAgent>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = agent.config.walkSound;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (audioSource.isPlaying)
        {
            audioSource.volume = Random.Range(0.8f, 1);
            audioSource.pitch = Random.Range(0.8f, 1);
        }
        
    }

    public void Run()
    {

        audioSource.clip = agent.config.runSound;
        audioSource.Play();
    }

    public void Walk()
    {
        audioSource.clip = agent.config.walkSound;
        audioSource.Play();

    }

    public void Stop()
    {
        audioSource.Stop();
    }
}
