using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    private float lowerBound = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }

        if(transform.position.x > 17 || transform.position.x < -17)
        {
            Destroy(gameObject);
        }
    }


}
