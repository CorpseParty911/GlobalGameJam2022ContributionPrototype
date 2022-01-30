using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public GameObject goal;
    public float snapRate;
    private bool placed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Placed()
    {
        return placed;
    }

    public bool Snap()
    {
        if (((this.transform.position - goal.transform.position).magnitude <= this.transform.localScale.x * snapRate / 100) && (((this.transform.eulerAngles - goal.transform.eulerAngles).magnitude <= snapRate) || (Mathf.Abs((this.transform.eulerAngles - goal.transform.eulerAngles).magnitude - 360) <= snapRate)))
        {
            this.transform.position = goal.transform.position + new Vector3(0, 0, -0.1f);
            this.transform.eulerAngles = goal.transform.eulerAngles;
            placed = true;
            return true;
        }
        return false;
    }
}
