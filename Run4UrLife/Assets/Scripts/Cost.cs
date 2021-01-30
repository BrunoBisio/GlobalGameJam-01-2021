using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost
{
    public float timeCost;
    public states state;

    public Cost(float timeCost, states state)
    {
        this.timeCost = timeCost;
        this.state = state;
    }
}
