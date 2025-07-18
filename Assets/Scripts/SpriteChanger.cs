using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public Sprite[] m_characterSr;
    public float m_jumpRotation;
    public Vector2 m_jumpForce;

    public void ChangeSprite(int n)
    {
        var sr = this.GetComponent<SpriteRenderer>();
        sr.sprite = m_characterSr[n];

        var tr = this.GetComponent<Transform>();
        if (n == 1)
        {
            tr.eulerAngles = new Vector3(0, 0, m_jumpRotation);
        }
        else
        {
            tr.eulerAngles = new Vector3(0, 0, 0);
        }
    }
        
}
