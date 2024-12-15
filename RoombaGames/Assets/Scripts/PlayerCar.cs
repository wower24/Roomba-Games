using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCar : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        //check whether player is touching left or right part of the screen
        //IMPORTANT: GetMouseButton() also checks if it is held down
        //           while GetMouseButtonDown() registers it only once
        if(Input.GetMouseButton(0)) {
            //convert position to World Point so center is 0, easier to tell left from right
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(touchPos.x < 0) {
                //SLIDE TO THE LEFT
                rb.AddForce(Vector2.left * moveSpeed);

            } 
            else {
                //SLIDE TO THE RIGHT
                rb.AddForce(Vector2.right * moveSpeed);

            }
        } 
        //when no touch - stop the player
        else {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Block") {
            Invoke("GoBackToMenu", 3);
        }
    }

    void GoBackToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
