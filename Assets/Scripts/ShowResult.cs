using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    Text m_centerText;
    [SerializeField] GameObject m_button;

    // Start is called before the first frame update
    void Start()
    {
        var centerText = GameObject.Find("CenterText");
        m_centerText = centerText.GetComponent<Text>();

        if (m_button)
        {
            m_button.SetActive(false);
        }
    }

    public void EndEffect(string result)
    {
        var slashEffect1 = GameObject.Find("SlashEffect1");
        slashEffect1.GetComponent<ParticleSystem>().Play();
        var slashEffect2 = GameObject.Find("SlashEffect2");
        slashEffect2.GetComponent<ParticleSystem>().Play();
        var leafEffect = GameObject.Find("LeafEffect");
        leafEffect.GetComponent<ParticleSystem>().Play();

        GameObject[] players = new GameObject[2];
        players[0] = GameObject.Find("Player1");
        players[1] = GameObject.Find("Player2");

        foreach (var player in players)
        {
            var rb = player.GetComponent<Rigidbody2D>();
            var sc = player.GetComponent<SpriteChanger>();
            rb.WakeUp();
            
            sc.ChangeSprite(2);
        }

        m_centerText.text = result + "ÇÃèüóò";

        if (m_button)
        {
            m_button.SetActive(true);
        }
    }
}
