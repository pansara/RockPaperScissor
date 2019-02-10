using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    enum elements { Rock = 1, Paper, Scissor }

    private int pChoice = -1;
    private int cChoice = -1;

    private bool pTurn = true;

    public GameObject WinningText;
    public GameObject FWinner;

    public Sprite rockImg, paperImg, scissorImg;
    public GameObject cChooseImg;
    public GameObject pChooseImg;

    public Button rock;
    public Button paper;
    public Button scissor;

    private int cWins = 0;
    private int pWins = 0;
    private int nTurns = 0;

    // Update is called once per frame
    void Update()
    {
        if (pTurn && pChoice == -1)
        {
            return;
        }
        else
        {
            cChoose();
            checkWinner();
            pChoice = -1;
            pTurn = true;
        }

    }

    void checkWinner()
    {
        if(pChoice == cChoice)
        {
            //draw
            WinningText.GetComponent<Text>().text = "DRAW";
            WinningText.GetComponent<Text>().color = Color.black;
        }
        else if(pChoice == (int)elements.Paper && cChoice == (int)elements.Rock)
        {
            //player wins
            pWins++;
            WinningText.GetComponent<Text>().text = "PLAYER WINS!!";
            WinningText.GetComponent<Text>().color = Color.green;
        }
        else if (pChoice == (int)elements.Rock && cChoice == (int)elements.Paper)
        {
            //computer wins
            cWins++;
            WinningText.GetComponent<Text>().text = "COMPUTER WINS!!";
            WinningText.GetComponent<Text>().color = Color.red;
        }
        else if (pChoice == (int)elements.Scissor && cChoice == (int)elements.Rock)
        {
            //computer wins
            cWins++;
            WinningText.GetComponent<Text>().text = "COMPUTER WINS!!";
            WinningText.GetComponent<Text>().color = Color.red;
        }
        else if (pChoice == (int)elements.Rock && cChoice == (int)elements.Scissor)
        {
            //player wins
            pWins++;
            WinningText.GetComponent<Text>().text = "PLAYER WINS!!";
            WinningText.GetComponent<Text>().color = Color.green;
        }
        else if (pChoice == (int)elements.Paper && cChoice == (int)elements.Scissor)
        {
            //computer wins
            cWins++;
            WinningText.GetComponent<Text>().text = "COMPUTER WINS!!";
            WinningText.GetComponent<Text>().color = Color.red;
        }
        else if (pChoice == (int)elements.Scissor && cChoice == (int)elements.Paper)
        {
            //player wins
            pWins++;
            WinningText.GetComponent<Text>().text = "PLAYER WINS!!";
            WinningText.GetComponent<Text>().color = Color.green;
        }
        nTurns++;

        if(nTurns >= 10)
        {
            string winner;
            if(cWins > pWins)
            {
                winner = "COMPUTER";
            }
            else if(pWins > cWins)
            {
                winner = "PLAYER";
            }
            else
            {
                winner = "DRAW";
            }

            FWinner.GetComponent<Text>().text = "FINAL WINNER: " + winner;
            FWinner.GetComponent<Text>().color = Color.magenta;
            rock.gameObject.SetActive(false);
            paper.gameObject.SetActive(false);
            scissor.gameObject.SetActive(false);
            pChooseImg.SetActive(false);
            cChooseImg.SetActive(false);
            WinningText.SetActive(false);
        }


    }

    public void pChoose(int choose)
    {
        pChoice = choose;
        pTurn = false;  //Computer turn

        if (pChoice == 1)
        {
            pChooseImg.GetComponent<Image>().sprite = rockImg;
        }
        else if (pChoice == 2)
        {
            pChooseImg.GetComponent<Image>().sprite = paperImg;
        }
        else
        {
            pChooseImg.GetComponent<Image>().sprite = scissorImg;
        }
    }

    public void cChoose()
    {
        cChoice = Random.Range(1, 4);
        if(cChoice == 1)
        {
            cChooseImg.GetComponent<Image>().sprite = rockImg;
        }
        else if (cChoice == 2)
        {
            cChooseImg.GetComponent<Image>().sprite = paperImg;
        }
        else
        {
            cChooseImg.GetComponent<Image>().sprite = scissorImg;
        }
    }
}
