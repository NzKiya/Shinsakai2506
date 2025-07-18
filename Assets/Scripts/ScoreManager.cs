using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //GameObject m_player1;
    //GameObject m_player2;
    GameObject[] m_players;

    //GameObject m_score1Text;
    //GameObject m_score2Text;
    GameObject[] m_scoreTexts;

    // Start is called before the first frame update
    void Start()
    {
        m_players = new GameObject[2];
        m_players[0] = GameObject.Find("Player1");
        m_players[1] = GameObject.Find("Player2");

        m_scoreTexts = new GameObject[2];
        m_scoreTexts[0] = GameObject.Find("Score1Text");
        m_scoreTexts[1] = GameObject.Find("Score2Text");
    }

    public void AddScore()
    {
        //var gameManagerobj = GameObject.Find("GameManager");
        //var gameManager = gameManagerobj.GetComponent<GameManager>();

        for (int i = 0; i < 2; i++)
        {
            var commandManager = m_players[i].GetComponent<CommandManager>();
            int score = commandManager.m_score;

            var scoreText = m_scoreTexts[i].GetComponent<Text>();
            scoreText.text = score + " ˜AŒ‚";

            //if (gameManager.m_timeLimit - gameManager.m_timer < 3)
            //{
            //    scoreText.enabled = false;
            //}
        }
        
    }
}
