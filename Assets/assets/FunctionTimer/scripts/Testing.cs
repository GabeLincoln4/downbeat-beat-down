using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private BeatClock beatClock;

    private void Start()
    {
        beatClock = new BeatClock(TestingAction, TestingAction2, 105f);
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    private void TestingAction()
    {
        Debug.Log("Boom");
    }

    private void TestingAction2()
    {
        Debug.Log("Tum");
    }
}
