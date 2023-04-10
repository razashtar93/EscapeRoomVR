using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject woodenDoorFirst;
    public GameObject woodenDoorSecond;
    public GameObject gate; 
    public SoundEffects soundEffect = null;
    public AnimationController animationControllerDoorDown;
    public AnimationController animationControllerDoorUp;
    public AnimationController animationControllerGate;

    private Vector3 startPosition = new Vector3(-26.91f, -11.574f, 46.68f);
    private Vector3 startDirection = new Vector3(0, 442.383f, 0);

    // Start is called before the first frame update
    void Start()
    {
        setPlayerPositionAndDirection(startPosition, startDirection);
    }

    public void openWoodDoorFirstFloor(GameObject woodenDoorFirst)
    {
        //Debug.Log("Open First Wooden Door");
        animationControllerDoorDown.PlayAnimation();
        soundEffect.PlayWoodenDoorSound();
    }

    public void openWoodDoorSecondFloor(GameObject woodenDoorSecond)
    {
        //Debug.Log("Open Second Wooden Door");
        animationControllerDoorUp.PlayAnimation();
        soundEffect.PlayWoodenDoorSound();
    }


    public void openGates(GameObject gate) // later on combined all the 3 function to 1 if we have time
    {
        //Debug.Log("Gate is open");
        animationControllerGate.PlayAnimation();
        soundEffect.PlayBarredGateSound();
    }

    public void setPlayerPositionAndDirection(Vector3 position, Vector3 direction)
    {
        gameObject.transform.position = position;
        gameObject.transform.rotation = Quaternion.Euler(direction);
    }

    public void teleportPlayerInStairs()
    {
        setPlayerPositionAndDirection(new Vector3(-22.65f, 0.36f, 17.59f), new Vector3(2.124f, 80.832f, 0.058f));
    }
}
