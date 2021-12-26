using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public GameObject musicNote;
    public Animator musicNoteAnimator;
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 0.9f;
    float seconds;
    float bps = 1.583f;
    float firstBeat;
    private float timer = 95f;
    private float songBeats;
    
    // long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        
        firstBeat = 1.0f;

        Debug.Log("Testing");

        musicNote = GameObject.Find("Music Note");
        musicNoteAnimator = musicNote.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        timer = 30 / timer;
        timer -= Time.deltaTime;
        seconds = Time.time;
        songBeats = Conductor.instance.loopPositionInAnalog;

        if(songBeats >= 0.2f && songBeats <= 0.6f)
        {
            animator.SetBool("OnBeat", true);
        }
        else
        {
            animator.SetBool("OnBeat", false);
        }

        if (seconds == 1)
        {
            Debug.Log("1");
        }


        if(Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (animator.GetBool("OnBeat") == true)
            {
                musicNoteAnimator.SetTrigger("ContactOnBeat");
                
                
               
                Debug.Log("Extra Damage");
            }
            lastClickedTime = Time.time;
            noOfClicks++;
            if(noOfClicks == 1)
            {
                animator.SetBool("Hit1", true);
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        }

    }

    public void return1()
    {
        if(noOfClicks >= 2)
        {
            animator.SetBool("Hit2", true);
        }
        else
        {
            animator.SetBool("Hit1", false);
            noOfClicks = 0;
        }
    }

    public void return2()
    {
        if(noOfClicks >= 3)
        {
            animator.SetBool("Hit3", true);
        }
        else
        {
            animator.SetBool("Hit2", false);
            animator.SetBool("Hit1", false);
            noOfClicks = 0;

        }
    }

    public void return3()
    {
        animator.SetBool("Hit1", false);
        animator.SetBool("Hit2", false);
        animator.SetBool("Hit3", false);
        noOfClicks = 0;
    }
}
