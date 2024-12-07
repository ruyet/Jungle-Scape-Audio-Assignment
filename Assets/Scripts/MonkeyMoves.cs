using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;

public class MonkeyMoves : MonoBehaviour
{

    public AudioClip[] monkeys;
    public AudioSource monkeySource;

    private int selectMonkey;
    private float monkeyPitch;
    private float timer;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        monkeyPitch = Random.Range(0.5f, 1.5f);
        selectMonkey = Random.Range(0, monkeys.Length);
        time += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > time)
        {
            //play sound
            monkeySource.clip = monkeys[selectMonkey];
            monkeySource.pitch = monkeyPitch;
            monkeySource.Play();
            //recalculate
            timer = 0;
            monkeyPitch = Random.Range(0.5f, 1.5f);
            selectMonkey = Random.Range(0, monkeys.Length);
            time += Time.deltaTime;
        }

    }
}
