using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 5;
        //Define the speed at which the object moves

        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the horizontal axis

        

        transform.Translate(new Vector2(horizontalInput, 0) * moveSpeed * Time.deltaTime);
    }
}
