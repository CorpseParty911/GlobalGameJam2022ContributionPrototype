using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePuzzle : MonoBehaviour
{
    public GameObject[] BonePrefab;
    public GameObject[] BoneSlotPrefab;
    public int difficultyLevel;

    private int boneCount;
    private List<GameObject> bones;
    private List<GameObject> boneSlots;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Timer>().timeRemaining = 90 - (difficultyLevel > 1 ? 30 : 0);
        boneCount = 1 + difficultyLevel * 5;
        bones = new List<GameObject>();
        boneSlots = new List<GameObject>();
        GameObject go = GameObject.Instantiate(BoneSlotPrefab[difficultyLevel - 1]);
        foreach (SpriteRenderer r in go.GetComponentsInChildren<SpriteRenderer>())
            boneSlots.Add(r.gameObject);
        go = GameObject.Instantiate(BonePrefab[difficultyLevel - 1]);
        foreach (SpriteRenderer r in go.GetComponentsInChildren<SpriteRenderer>())
            bones.Add(r.gameObject);

        for (int i = 0; i < boneCount; ++i)
        {
            bones[i].GetComponent<PuzzlePiece>().goal = boneSlots[i];
            bones[i].transform.position = new Vector3(Random.Range(3, 5), Random.Range(-2, 2), -0.01f);
            bones[i].transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 35) * 10);
            boneSlots[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
