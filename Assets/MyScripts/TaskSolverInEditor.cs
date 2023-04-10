using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSolverInEditor : MonoBehaviour
{

    public GameObject player;
    public GameObject hatDisable;
    public GameObject hatOnHead;
    public GameObject screen;
    public GameObject button;
    public GameObject gate;
    public GameObject openGateUI;
    public PlayerController PlayerController;
    public KeypadController KeypadController;

    private List<System.Action> functionListTaskOne = new List<System.Action>();
    private List<System.Action> functionListTaskTwo = new List<System.Action>();
    private List<System.Action> functionListTaskThree = new List<System.Action>();

    // Start is called before the first frame update
    void Start()
    {
        functionListTaskOne.Add(TaskOneFunction1);
        functionListTaskOne.Add(TaskOneFunction2);
        functionListTaskOne.Add(TaskOneFunction3);
        functionListTaskOne.Add(TaskOneFunction4);


        functionListTaskTwo.Add(TaskTwoFunction1);
        functionListTaskTwo.Add(TaskTwoFunction2);
        functionListTaskTwo.Add(TaskTwoFunction3);
        functionListTaskTwo.Add(TaskTwoFunction4);
        functionListTaskTwo.Add(TaskTwoFunction5);
        functionListTaskTwo.Add(TaskTwoFunction6);
        functionListTaskTwo.Add(TaskTwoFunction7);


        functionListTaskThree.Add(TaskThreeFunction1);
        functionListTaskThree.Add(TaskThreeFunction2);
        functionListTaskThree.Add(TaskThreeFunction3);
        functionListTaskThree.Add(TaskThreeFunction4);
        functionListTaskThree.Add(TaskThreeFunction5);
        functionListTaskThree.Add(TaskThreeFunction6);
        functionListTaskThree.Add(TaskThreeFunction7);
        functionListTaskThree.Add(TaskThreeFunction8);
    }

    public void SolveTaskOne()
    {
        Debug.Log("Start Solving Task 1");
        StartCoroutine(ExecuteFunctions(functionListTaskOne));
    }

    public void SolveTaskTwo()
    {
        Debug.Log("Start Solving Task 2");
        StartCoroutine(ExecuteFunctions(functionListTaskTwo));
    }

    public void SolveTaskThree()
    {
        Debug.Log("Start Solving Task 3");
        StartCoroutine(ExecuteFunctions(functionListTaskThree));
    }

    private IEnumerator ExecuteFunctions(List<System.Action> functionsList)
    {
        foreach (var function in functionsList)
        {
            // Call the function
            function();

            // Wait for 3 seconds before continuing to the next function
            yield return new WaitForSeconds(3);
        }
    }

    private void TaskOneFunction1()
    {
        Debug.Log("Player look at mirror and see hat on his head");
        // player see mirror
        PlayerController.setPlayerPositionAndDirection(new Vector3(-0.4f, -10.84f, 35.73f), new Vector3(2.124f, 1.567f, 0.058f));
    }

    private void TaskOneFunction2()
    {
        Debug.Log("Player see the hook");
        //player see hook
        PlayerController.setPlayerPositionAndDirection(new Vector3(-0.4f, -10.84f, 34.71f), new Vector3(2.124f, 167.281f, 0.058f));
    }

    private void TaskOneFunction3()
    {
        Debug.Log("Player put hat on hook");
        //hat position on hook
        hatDisable.gameObject.SetActive(true);
    }

    private void TaskOneFunction4()
    {
        Debug.Log("Hat on hook open the door --> Task 1 is Done");
        //player position to see door open
        PlayerController.setPlayerPositionAndDirection(new Vector3(-15.06f, -10.84f, 18.13f), new Vector3(2.124f, 248.125f, 0.058f));
        hatDisable.gameObject.SetActive(false);
        hatOnHead.gameObject.SetActive(false);
        //Debug.Log("Task 1 is Done");
    }

    private void TaskTwoFunction1() // TASK 2 ---------------------------------------------
    {
        Debug.Log("Position player in up floor");
        //move player to up floor
        PlayerController.teleportPlayerInStairs();
    }

    private void TaskTwoFunction2()
    {
        Debug.Log("Player click on the UI button");
        //move player to see ui
        PlayerController.setPlayerPositionAndDirection(new Vector3(-11.91f, 0.76f, 17.7f), new Vector3(2.124f, 187.79f, 0.058f));
    }

    private void TaskTwoFunction3()
    {
        Debug.Log("Click on button open gate");
        //move player to see gate open + open gate + disable UI
        PlayerController.setPlayerPositionAndDirection(new Vector3(-11.83f, 0.78f, 15.48f), new Vector3(2.124f, 15.051f, 0.058f));
        PlayerController.openGates(gate);
        openGateUI.gameObject.SetActive(false);
    }

    private void TaskTwoFunction4()
    {
        Debug.Log("Player look at the time in the clock: 12:35");
        //move player to see clock
        PlayerController.setPlayerPositionAndDirection(new Vector3(-9.16f, 0.16f, 21.9f), new Vector3(2.124f, 188.597f, 0.058f));
    }

    private void TaskTwoFunction5()
    {
        Debug.Log("Player see password system and remember the time 12:35");
        //move player to see password system 
        PlayerController.setPlayerPositionAndDirection(new Vector3(-5.68f, 1.18f, 16.25f), new Vector3(-4.12f, 28.372f, 1.022f));
    }

    private void TaskTwoFunction6()
    {
        Debug.Log("Player put '1235' as password");
        //put password in keypad

        KeypadController.KeyEntry(1235);
        
    }

    private void TaskTwoFunction7()
    {
        Debug.Log("Password is correct and door is open --> Task 2 is Done");
        //correct password door is open  
        KeypadController.CheckEntry();
    }

    private void TaskThreeFunction1() // TASK 3 -------------------------------------------------
    {
        Debug.Log("Player reach last room");
        // position the player in the last room 
        PlayerController.setPlayerPositionAndDirection(new Vector3(33.13f, -5.67f, 26.47f), new Vector3(2.124f, 68.483f, 0.058f));
    }

    private void TaskThreeFunction2()
    {
        Debug.Log("Player grab the remote and click on button");
        // position and rotate to look on remote
        PlayerController.setPlayerPositionAndDirection(new Vector3(37.98f, -5.67f, 28.19f), new Vector3(42.022f, 60.437f, -19.897f));
    }

    private void TaskThreeFunction3()
    {
        Debug.Log("The remote play video in the TV");
        // play video
        PlayVideo playVideo = screen.GetComponent<PlayVideo>();
        playVideo.TogglePlayPause();
    }

    private void TaskThreeFunction4()
    {
        Debug.Log("Player see on TV the clue and understand he need to find button to push ");
        // position and rotate to look on TV + activate button
        PlayerController.setPlayerPositionAndDirection(new Vector3(37.98f, -5.67f, 26.59f), new Vector3(-10.66f, 22.583f, 5.147f));
        button.gameObject.SetActive(true);
    }

    private void TaskThreeFunction5()
    {
        Debug.Log("Player see button and text above");
        // position and rotation the player to see the button and the text above 
        PlayerController.setPlayerPositionAndDirection(new Vector3(37.54f, -5.67f, 26.33f), new Vector3(-10.66f, 132.574f, 5.147f));
    }

    private void TaskThreeFunction6()
    {
        Debug.Log("Player understand he need dynamic object to push the button");
        // position the player to see the text better
        PlayerController.setPlayerPositionAndDirection(new Vector3(40.03f, -5.67f, 23.85f), new Vector3(-65.894f, 104.755f, -18.083f));
    }

    private void TaskThreeFunction7()
    {
        Debug.Log("Player see dynamic objects (tennis rocket, tennis ball, remote .. )");
        // position the player to see dynamic objects he can push with (tennis rocket, tennis ball, remote .. )
        PlayerController.setPlayerPositionAndDirection(new Vector3(41.36f, -6f, 25.24f), new Vector3(28.646f, 13.179f, 2.993f));
    }

    private void TaskThreeFunction8()
    {
        Debug.Log("Pushing the button using object will finish the game --> Task 3 is Done");
        // position the player to see the button closly (don't push because it will finish the game and take you to lobby room)
        PlayerController.setPlayerPositionAndDirection(new Vector3(40.8f, -5.69f, 22.31f), new Vector3(-4.935f, 182.906f, -1.883f));
    }
}
