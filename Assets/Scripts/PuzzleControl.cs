using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleControl : MonoBehaviour
{
    public AudioSource sans;
    public AudioSource yeet;
    public AudioSource doot;
    public AudioSource fuck;
    public GameObject selectedObject;
    Vector3 offset;

    private void Awake()
    {
        sans.Play();
        sans.Pause();
        AudioListener.volume = GameManager.instance.MasterVolume();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject && !(targetObject.GetComponent<PuzzlePiece>().Placed()))
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
            }
        }

        if (selectedObject)
        {
            sans.UnPause();
            Cursor.visible = false;
            if (Input.mouseScrollDelta.y > 0)
            {
                selectedObject.transform.Rotate(new Vector3(0, 0, 10));
            } 
            else if (Input.mouseScrollDelta.y < 0)
            {
                selectedObject.transform.Rotate(new Vector3(0, 0, -10));
            }
            selectedObject.transform.position = mousePosition + offset;

        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            sans.Pause();
            Cursor.visible = true;
            if (selectedObject.GetComponent<PuzzlePiece>())
            {
                if (selectedObject.GetComponent<PuzzlePiece>().Snap())
                {
                    PuzzlePiece[] pieces = FindObjectsOfType<PuzzlePiece>();
                    int i;
                    for (i = 0; i < pieces.Length; i++)
                    {
                        if (!pieces[i].Placed())
                            break;
                    }
                    if (i >= pieces.Length)
                    {
                        yeet.Play();
                        FindObjectOfType<Timer>().timerIsRunning = false;
                    }
                    else
                    {
                        doot.Play();
                    }
                }
                else
                {
                    fuck.Play();
                }
            }
            selectedObject = null;
        }
    }
}
