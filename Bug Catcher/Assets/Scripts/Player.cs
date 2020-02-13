using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // the speed of the Player
    [SerializeField] float speed = 0f;

    // the range that the Player can pickup a Bug
    [SerializeField] float pickupRange = 0f;

    // the size of the player's inventory
    [SerializeField] int inventorySize = 0;

    // the Player's inventory
    Inventory inventory;

    // a referece to the Game Controller
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        // creates an empty Inventory
        this.inventory = new Inventory(this.inventorySize);
        // sets up the reference to the Game Controller
        this.setupReferenceToGameController();
    }

    // Update is called once per frame
    private void Update()
    {
        // moves this player
        this.move();
        // picks up a Bug if the correct conditions are met
        this.maybePickup();
    }

    void setupReferenceToGameController()
    {
        this.gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // moves this player if a key is pressed
    void move()
    {
        // the current inputs from the horizontal and verticle axes
        float horinzontalSpeed = Input.GetAxisRaw("Horizontal") * this.speed;
        float verticalSpeed = Input.GetAxisRaw("Vertical") * this.speed;

        // the current position of this Player
        Vector3 currentPos = this.transform.position;

        // if both the horizontal and vertical inputs are being pressed
        if (horinzontalSpeed != 0 && verticalSpeed !=0)
        {
            // move this player diagonally the same speed as if they would be moving horizontally or vertically
            this.transform.position = new Vector3(currentPos.x + horinzontalSpeed / Mathf.Sqrt(2),
                currentPos.y + verticalSpeed / Mathf.Sqrt(2));
        } else
        {
            // move this player horizontally or vertically
            this.transform.position = new Vector3(currentPos.x + horinzontalSpeed, currentPos.y + verticalSpeed);
        }

    }

    // is this Player close enough to a Bug to be able to pick it up?
    bool playerCanPickup()
    {
        bool canPickup = false; // this Player cannot pick up a Bug yet
        Vector3 pos = this.transform.position; // gets a reference to the Player position
        GameObject[] bugs = this.gameController.existingBugs(); // the list of Bugs in the game

        foreach (GameObject bug in bugs)
        {
            float distance = Vector3.Distance(bug.transform.position, pos); // the distance between a Bug in the game and the Player

            // if the distance is less than the pickup range
            if (distance < this.pickupRange)
            {
                canPickup = true; // the Player can pickup a Bug
            }

        }

        return canPickup;
    }

    // picks up a Bug if the Player is close enough and has space in the Inventory
    void maybePickup()
    {

        // if this player can pickup a Bug and the inventory is not full
        if (this.playerCanPickup() && !this.inventory.isFull() && Input.GetKeyDown("f") && this.gameController.existingBugs().Length != 0)
        {
            GameObject bugToPickup = this.closestBug(); // the closest bug 
            this.inventory.add(bugToPickup);
            Object.Destroy(bugToPickup);
        }

    }

    // should only be called if in conjunction with: this.gameController.existingBugs().Length != 0
    // finds the Bug that is closest to this Player
    GameObject closestBug()
    {
        float closestDistance = this.pickupRange; // the highest possible distance is the pickup range
        GameObject closestBug = null; // the closest bug is currently null
        Vector3 pos = this.transform.position; // gets a reference to the Player position
        GameObject[] bugs = this.gameController.existingBugs(); // the list of Bugs in the game

        foreach (GameObject bug in bugs)
        {
            float distance = Vector3.Distance(bug.transform.position, pos); // the distance between a Bug in the game and the Player

            // if the distance is less than the closest distance so far
            if (distance < closestDistance)
            {
                closestDistance = distance; // set the closest distance to the distance to the current bug
                closestBug = bug; // set the closest bug to the current bug
            }
        }

        return closestBug;
    }

}
