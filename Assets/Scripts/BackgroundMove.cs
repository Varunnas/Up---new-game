using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float width;
    private Vector3 startPos;
    private GameManager gameManagerScript;
    public float speed;
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        startPos = transform.position;
        width = GetComponent<BoxCollider>().size.y /2 ;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isGameActive)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            if (transform.position.y < startPos.y - width)
            {
                transform.position = startPos;
            }
        }
        
    }
}
