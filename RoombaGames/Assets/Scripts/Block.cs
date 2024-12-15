using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LINEAR DRAG >> 0 makes it fall slower
public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6f) {
            Destroy(gameObject);
        }
    }
}
