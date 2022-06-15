using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TwinsGameManager : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] faceImage;

    public List <Button> btns = new List<Button>();

    public List<Sprite> gameFace = new List<Sprite>();

    private bool firstGuess, secondGuess;

    private int countGuess;
    private int countCorrectGuess;
    private int gameGuess;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessFace, secondGuessFace;


    void Awake()
    {
        faceImage = Resources.LoadAll<Sprite>("Images/image");
    }

    private void Start() {
        
        GetButtons();
        AddListeners();
        AddGameFace();
        Shuffle(gameFace);
        gameGuess = gameFace.Count / 3;
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("TwinsField");

        for(int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
            
        }
    }


    void AddGameFace()
    {

        int lopper = btns.Count;
        int index = 0;

        for(int i = 0; i < lopper; i++)
        {
            if(index == lopper / 3)
            {
                index = 0;
            }
            // gameFace.Add(faceImage[index]);
            gameFace.Add(faceImage[index]);
            index++;

        }
    }

    void AddListeners()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAFace());
        }
    }


    public void PickAFace()
    {        
        if(!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessFace = gameFace[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gameFace[firstGuessIndex];
        }
        else if(!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessFace = gameFace[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gameFace[secondGuessIndex];

            StartCoroutine(CheckIfMatch());
        }
    }

    IEnumerator CheckIfMatch()
    {
        yield return new WaitForSeconds(.5f);

        if(firstGuessFace == secondGuessFace)
        {
            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIFgameIsFinished();
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;

            
        }
        yield return new WaitForSeconds(.5f);
        firstGuess = secondGuess = false;

    }

    void CheckIFgameIsFinished()
    {
        countCorrectGuess++;
        if(countCorrectGuess == gameGuess)
        {
            SceneManager.LoadScene("Game");
            print("It took you " + countGuess + " guesses to finish the game");
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    


    
}