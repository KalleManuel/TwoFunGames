using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    [SerializeField]
    public InputField input;

    [SerializeField]
    public Text challangeText;
    public Text theGuessText;
    public Text lifeCounter;


    public int theNumber;

    public int highRange = 20;
    public int lowRange = 0;
    public Text comments;

    public int AmountOfTries;

    public GameObject winFloor;
    public GameObject looseFloor;
    public Text endText;

    public GameObject playerDisplay;
    public Text playerGuesses;




    // Start is called before the first frame update
    void Start()
    {
        AmountOfTries = 5;
        lifeCounter.text = "Tries left; " + AmountOfTries;

        lowRange = Random.Range(0, 10);
        highRange = Random.Range(11, 40);

        theNumber = Random.Range(lowRange, highRange);

        playerDisplay.SetActive(true);
        winFloor.SetActive(false);
        looseFloor.SetActive(false);
        endText.text = "";
        playerGuesses.text = "";

        challangeText.text = "Guess a number between " + lowRange + "- " + highRange + ".";
    }

    // Update is called once per frame
    void Update()

    {


    }



    public void GetNumber(string guess)
    {
        theGuessText.text = "What about " + guess + "?";
        AmountOfTries--;
        lifeCounter.text = "Tries left; " + AmountOfTries;


        CheckNumber(int.Parse(guess));


        input.text = "";



    }

    public void CheckNumber(int guess)
    {
        bool youWin = false;

        if (theNumber > guess && AmountOfTries >= 1)
        {
            comments.text = "Nope, try a larger number.";
            playerGuesses.text = playerGuesses.text + " " + guess;

        }


        if (theNumber < guess && AmountOfTries >= 1)
        {
            comments.text = "Nope, try a smaller number.";
            playerGuesses.text = playerGuesses.text + " " + guess;
        }

        if (theNumber == guess && AmountOfTries >= 0)
        {
            challangeText.text = "Yeah! You're good!";
            comments.text = "The correct number is " + theNumber;
            winFloor.SetActive(true);
            playerDisplay.SetActive(false);
            endText.text = "YOU WIN!";
            youWin = true;

        }
        if (AmountOfTries == 0 && youWin == false)
        {
            challangeText.text = "Sorry, the number was " + theNumber + "!";
            comments.text = "";
            looseFloor.SetActive(true);
            playerDisplay.SetActive(false);
            endText.text = "YOU LOOSE!";

        }

    }

    
}