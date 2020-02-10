using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 0f;

    // Update is called once per frame
    private void Update()
    {
        // moves the player
        this.move();
    }

    // moves the player if a key is pressed
    void move()
    {
        // the current inputs from the horizontal and verticle axes
        float horinzontalSpeed = Input.GetAxisRaw("Horizontal") * this.speed;
        float verticalSpeed = Input.GetAxisRaw("Vertical") * this.speed;

        // the current position of the Player
        Vector3 currentPos = this.transform.position;

        // if the both the horizontal and vertical inputs are being pressed
        if (horinzontalSpeed != 0 && verticalSpeed !=0)
        {
            // move the player diagonally the same speed as if they would be moving horizontally or vertically
            this.transform.position = new Vector3(currentPos.x + horinzontalSpeed / Mathf.Sqrt(2),
                currentPos.y + verticalSpeed / Mathf.Sqrt(2));
        } else
        {
            // move the player horizontally or vertically
            this.transform.position = new Vector3(currentPos.x + horinzontalSpeed, currentPos.y + verticalSpeed);
        }

    }
}
