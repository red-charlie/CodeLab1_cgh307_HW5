using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //this is the camera follow script from my physics game
    GameObject Player;
    Vector3 currentPlayerPosition;
    public float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");//find the player in this game
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayerPosition = Player.transform.position; //get the players position
        Vector3 newPosition = new Vector3(currentPlayerPosition.x, transform.position.y, currentPlayerPosition.z); //get the ideal position for the camera

        transform.position = Vector3.Lerp(
             transform.position, 
             newPosition, 
            Time.deltaTime * cameraSpeed); //lerp between the two at the speed I set

         
    }
}
