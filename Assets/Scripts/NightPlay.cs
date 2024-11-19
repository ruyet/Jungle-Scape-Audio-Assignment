using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class NightPlay : MonoBehaviour {


    public AudioMixerSnapshot inToNight;
    public AudioMixerSnapshot outOfNight;
	public AudioClip[] chimes;
	public AudioSource chimesSource;
	public float bpm = 120;

	private float m_TransitionIn;
	private float m_TransitionOut;

	// Use this for initialization
	void Start () 
	{
		m_TransitionIn = 2.66f;
		m_TransitionOut = 4f;
	}

	void OnTriggerEnter(Collider night)
	{
		if (night.CompareTag("NightZone") && night)
		{
            inToNight.TransitionTo(m_TransitionIn);
			PlayChimes();
		}
	}

	void OnTriggerExit(Collider night)
	{
		if (night.CompareTag("NightZone") && night)
		{
            outOfNight.TransitionTo(m_TransitionOut);
        }
	}

	void PlayChimes()
	{
		int randClip = Random.Range (0, chimes.Length);
		chimesSource.clip = chimes[randClip];
		chimesSource.Play();
	}
}