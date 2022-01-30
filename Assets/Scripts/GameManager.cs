using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private uint score;
    private uint day;
    private uint mistakesMade;
    private float volume;
    private int fontSize;
    private int fontRange;
    private int minFont;

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<GameManager>();
                if (!_instance)
                {
                    GameObject newGO = new GameObject();
                    _instance = newGO.AddComponent<GameManager>();
                    DontDestroyOnLoad(_instance);
                }
            }
            return _instance;
        }
    }

    protected void Awake()
    {
        _instance = this as GameManager;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        day = 0;
        mistakesMade = 0;
        volume = 1.0f;
    }

    public void earnPoints(uint points)
    {
        score += points;
    }

    public void mistakesWereMade()
    {
        mistakesMade++;
        if (mistakesMade >= 1)
            Invoke("TooManyMistakes", 2);
    }

    public void TooManyMistakes()
    {
        Application.Quit();
    }

    public void passTime()
    {
        day++;
    }

    public float MasterVolume()
    {
        return volume;
    }

    public void setVolume(float value)
    {
        volume = value;
    }

    public void setFontSize(float size)
    {
        fontSize = minFont + (int)(fontRange * size);
    }
}
