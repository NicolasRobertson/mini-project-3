using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class pathFollower : MonoBehaviour
{
    Node[] PathNode;
    public GameObject Balloon;
    public Float MoveSpeed;
    float Timer;
    static Vector3 CurrentPositionHolder;
    int CurrentNode;
    // Start is called before the first frame update
    void Start()
    {
        PathNode = GetComponentsInChildren<PathNode>();
        CheckNode();
    }

    void CheckNode()
    {
        Timer = 0;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime * MoveSpeed;
        if (Balloon.transform.position != CurrentPositionHolder)
        {
            Balloon.transform.position = Vector3.Lerp(Balloon.transform.position, CurrentPositionHolder, Timer);
        }
        else
        {
            if (CurrentNode < PathNode.Length - 1)
            {
                CurrentNode++;
                CheckNode();
            }
        }
    }
}
