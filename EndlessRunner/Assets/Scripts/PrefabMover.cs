using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMover : MonoBehaviour
{
    public BackgroundMover bgsmover;

    // Start is called before the first frame update
    void Start()
    {
        bgsmover = FindObjectOfType<BackgroundMover>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(bgsmover.bgSpeed * Time.fixedDeltaTime, 0, 0);
    }
}
