using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public float bgSpeed = -7f;
    float speedIncrease;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(bgSpeed * Time.fixedDeltaTime, 0, 0);

        speedIncrease += Time.fixedDeltaTime;
        if(speedIncrease >= 15)
        {
            bgSpeed = bgSpeed - 1f;
            speedIncrease = 0f;
        }
    }
}
