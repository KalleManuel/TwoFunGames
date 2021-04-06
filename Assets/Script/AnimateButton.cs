using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateButton : MonoBehaviour


{
    // Letterboxes

    
    public Material newMat1;
    public Material newMat2;
   

    public float speed = 5.0f;
    public float currentX;
    public float currentY;
    public Vector3 target;

    public GameObject cube;
    public GameController2 foundALetter;

    public string guess;
    public Text buttonText;
    public string buttonTextToString;
   

    public bool isClicked = false;
    // public Button button;
  

    // Start is called before the first frame update
    void Start()
    {

        currentX = gameObject.transform.position.x;
        currentY = gameObject.transform.position.y;
        target = new Vector3(currentX, currentY, 84.5f);
        buttonText.text = "" + guess;


        

    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked == true)
        {
           //transform.position = new Vector3(currentX, currentY, 84.5f);
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        }
    }

    public void InsertChars()
    {
        foundALetter.inputChar = guess.ToString();
    }

    public void AnimateTheButton()
    {
         bool green = false;
        bool red = false;
        isClicked = true;


        if (foundALetter.foundLetter == true)
        {
            cube.GetComponent<MeshRenderer>().material = newMat1;
            green = true;
           

        }

        else if (foundALetter.foundLetter == false)
        {
            cube.GetComponent<MeshRenderer>().material = newMat2;
            red = true;

        }
        if (green == true  || red == true)
        {
            foundALetter.foundLetter = false;
        }

    }
}
