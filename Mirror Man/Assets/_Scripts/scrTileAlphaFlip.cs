using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class scrTileAlphaFlip : MonoBehaviour
{
    [SerializeField]
    private float initialAlpha = 1.0f;
    private float m_alpha;
    [SerializeField]
    private float m_speed = 0.1f;

    Tilemap tileMap;

    // Start is called before the first frame update
    void Start()
    {
        tileMap = GetComponent<Tilemap>();

        m_alpha = initialAlpha;
        tileMap.color = new Color(1f, 1f, 1f, m_alpha);
    }

    void Update()
    {
        if (m_alpha != initialAlpha)
        {
            tileMap.color = new Color(1f, 1f, 1f, m_alpha);
            AlphaFlip(initialAlpha);
        }
    }

    public void AlphaFlip(float a_endval)
    {
        if (m_alpha != a_endval)
        {
            if (m_alpha < a_endval)
            {
                m_alpha += m_speed * Time.deltaTime;
            }
            else
            {
                m_alpha -= m_speed * Time.deltaTime;
            }
        }
        initialAlpha = a_endval;
    }

    public float GetInitialAlpha() { return initialAlpha; }
}
