using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class ThunderPlay : MonoBehaviour
{

    public AudioMixerSnapshot intoThunder;
    public AudioMixerSnapshot outOfThunder;
    public AudioClip[] rolls;
    public AudioClip[] thunders;
    public AudioSource rollSource;
    public AudioSource thunderSource;

    private float m_TransitionIn;
    private float m_TransitionOut;
    private int selectThunder;
    private int selectRoll;
    private float timer01;
    private float timer02;
    private float time01;
    private float time02;

    // set time and clip selection for thunder rolls and thunders
    void Start()
    {
        selectThunder = Random.Range(0, thunders.Length);
        selectRoll = Random.Range(0, rolls.Length);
        time01 = Random.Range(15f, 35f);
        time02 = Random.Range(20f, 40f);
        m_TransitionIn = 1.66f;
        m_TransitionOut = 2.66f;
    }

    void OnTriggerEnter(Collider rain)
    {
        if (rain.CompareTag("ThunderStorm"))
        {
            intoThunder.TransitionTo(m_TransitionIn);
        }
    }
    void OnTriggerExit(Collider rain)
    {
        if (rain.CompareTag("ThunderStorm"))
        {
            outOfThunder.TransitionTo(m_TransitionOut);
        }
    }
    // run timers and change timers and selection
    void Update()
    {
        timer01 += Time.deltaTime;
        timer02 += Time.deltaTime;

        if (timer01 > time01)
        {
            thunderSource.clip = thunders[selectThunder];
            thunderSource.Play();
            time01 = Random.Range(15f, 35f);
            timer01 = 0;
            selectThunder = Random.Range(0, thunders.Length);
        }
        if (timer02 > time02)
        {
            rollSource.clip = rolls[selectRoll];
            rollSource.Play();
            time02 = Random.Range(20f, 40f);
            timer02 = 0;
            selectRoll = Random.Range(0, rolls.Length);

        }
    }
}
