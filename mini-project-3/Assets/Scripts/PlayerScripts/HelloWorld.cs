using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessFaller;

public class HelloWorld : MonoBehaviour
{
    int testNum = 0;
    IHealth armyMan = new Player();

    // Start is called before the first frame update
    void Start()
    {
        print ("Current health is " + armyMan.health);
    }

    // Update is called once per frame
    void Update()
    {
        testNum++;
        if (testNum >= 120)
        {
            testNum = 0;
            armyMan.ReduceHealth();
            print ("Ouch! My health is now " + armyMan.health);
        }
    }
}
