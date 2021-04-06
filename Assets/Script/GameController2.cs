using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController2 : MonoBehaviour
{
    // arrays of different words in different catagories

    public string[] animalArray;
    public string[] natureArray;
    public string[] foodArray;
    public string[] adjectiveArray;
    public string[] techArray;

    // one randomly choosen word from each catagory

    private string animal;
    private string nature;
    private string food;
    private string adjective;
    private string techStuff;

    // the five words put in an array

    private string[] words;

    // the secret word randomly chosen from the words array

    public string randomWord;

    // The displayed hidden word
    
    public string hiddenWord;
    public Text wordDisplay;

    // what player write in inputfield
    public string inputChar;
    public InputField inputField;

    // the wrong guesses displayed
   
    public Text wrongGuesses;

    // endplate content

    public Text winText;
    public Text endMessage;

    public GameObject endPlate;
    public GameObject winCube;
    public GameObject looseCube;
    public GameObject playerDisplay;
    public GameObject floor;

    public Color wincolor;
    public Color loosecolor;

    // the hangman

    public GameObject[] manParts;
    public int manPartIndex = 0;
    public int lives = 6;

    // makes hangman dangle

    public GameObject anchorPoint;

    // friendly hint displayed when two lives is left
    public Text hint;
    public int hintRadar;

    // times dead alive
    static int timesWin = 0;
    static int timesLoose = 0;
    public Text displayWin;
    public Text displayLoose;

    // Communicate with buttons
    public bool foundLetter = false;
    public GameObject keyboard;

    public bool gameover;

    void Start()
    {
       
        // Elements

        endPlate.SetActive(false);
        winCube.SetActive(false);
        looseCube.SetActive(false);
        manParts[0].SetActive(false);
        manParts[1].SetActive(false);
        manParts[2].SetActive(false);
        manParts[3].SetActive(false);
        manParts[4].SetActive(false);
        manParts[5].SetActive(false);
        playerDisplay.SetActive(false);
        floor.SetActive(true);
        keyboard.SetActive(true);


        // Generate words

        animal = animalArray[Random.Range(0, animalArray.Length - 1)];
        nature = natureArray[Random.Range(0, natureArray.Length -1)];
        food = foodArray[Random.Range(0, foodArray.Length - 1)];
        adjective = adjectiveArray[Random.Range(0, adjectiveArray.Length)];
        techStuff = techArray[Random.Range(0, techArray.Length -1)];

        words = new string[] { animal, nature, food, adjective, techStuff }; 

        randomWord = words[Random.Range(0, 4)];

        // Controlling displays

        gameover = false;

        hint.text = "";


        displayLoose.text = "= " + timesLoose;
        displayWin.text = "= " + timesWin;


        for (int i = 0; i < randomWord.Length; i++)
        {
            hiddenWord += "*";
        }

        wordDisplay.text = hiddenWord;

    }

    public void PressedA()
    {
       // inputChar = "a";
        CheckChar();
     
    }
    public void PressedB()
    {
        inputChar = "b";
        CheckChar();

    }

    public void PressedC()
    {
        inputChar = "c";
        CheckChar();

    }
    public void PressedD()
    {
        inputChar = "d";
        CheckChar();

    }

    public void PressedE()
    {
        inputChar = "e";
        CheckChar();

    }






    /*public void GetChars(string guess)
    {
        
        inputChar = guess.ToLower();
        CheckChar();
        inputField.text = "";
      
    }    */


    void CheckChar()
    {
        int charIndex = 0;
       
   
        //Check if the player guess can be found in the random word

        for (int i = 0; i < randomWord.Length; i++)
        {
           
            if (randomWord[i].ToString() == inputChar)
            {
                foundLetter = true;
                
    
                charIndex = i;

           
                hiddenWord = hiddenWord.Remove(charIndex, 1);

               
                hiddenWord = hiddenWord.Insert(charIndex, inputChar);


                wordDisplay.text = hiddenWord;

            }

            // and if not...
          
        }
        if (!foundLetter)
        {
            wrongGuesses.text = wrongGuesses.text + inputChar;
            lives--;
            manPartIndex++;
        }


        TheHangingMan();
        Hint();
        ResultBoard();

    }

    void Hint()
    {

        // hint

        if (lives <= 2 && randomWord == animal)
        {
            hint.text = "Hrm... I think the word is some kind of animal";
        }

        if (lives <= 2 && randomWord == food)
        {
            hint.text = "Hello... I think the word is something you can eat or drink";
        }

        if (lives <= 2 && randomWord == techStuff)
        {
            hint.text = "Help me... I think the word has something to do with tech";
        }

        if (lives <= 2 && randomWord == nature)
        {
            hint.text = "Psst... I think the word has something to do with nature";
        }

        if (lives <= 2 && randomWord == adjective)
        {
            hint.text = "I don't want to be a besserwiesser... but I belive the word is an adjective";
        }

    }

    void ResultBoard()
    {
        // if you win

        if (randomWord == hiddenWord)
        {
            endPlate.SetActive(true);
            playerDisplay.SetActive(false);
            floor.SetActive(false);
            winCube.SetActive(true);
            winText.color = wincolor;
            endMessage.color = wincolor;
            keyboard.SetActive(false);
            gameover = true;

            winText.text = "YOU WIN!";
            timesWin++;
            hint.text = "Geee... Thanx! Wanna play again?";
        }

        // if you loose

        if (lives == 0)
        {
            endPlate.SetActive(true);
            looseCube.SetActive(true);
            floor.SetActive(false);
            playerDisplay.SetActive(false);
            keyboard.SetActive(false);
            anchorPoint.transform.Rotate(-25, -25, 0);
            winText.color = loosecolor;
            endMessage.color = loosecolor;
            gameover = true;

            winText.text = "YOU LOSE!";
            timesLoose++;
            
            wordDisplay.text = randomWord;
            hint.text = "Urgghhhh...";
        }

        displayLoose.text = "= " + timesLoose;
        displayWin.text = "= " + timesWin;



    }

    void TheHangingMan()
    {
        // makes the diffeerent part of the man appear

        if (manPartIndex == 1)
        {
            manParts[0].SetActive(true);
        }

        if (manPartIndex == 2)
        {
            manParts[1].SetActive(true);
        }

        if (manPartIndex == 3)
        {
            manParts[2].SetActive(true);
        }

        if (manPartIndex == 4)
        {
            manParts[3].SetActive(true);
        }

        if (manPartIndex == 5)
        {
            manParts[4].SetActive(true);
        }

        if (manPartIndex == 6)
        {
            manParts[5].SetActive(true);
        }
    }

    public void HangmanR()
    {
        if (gameover == true)
        {
            SceneManager.LoadScene(2);
           

        }
        else
        {
            SceneManager.LoadScene(2);
            timesLoose++;
        }


    }
  
}
