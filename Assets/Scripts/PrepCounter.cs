﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepCounter : MonoBehaviour, ICollider
{
    public ColliderType ColliderType;
    public ChoppingBoard ChopBoard;
    public ServingPlate ServingBowl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public ColliderType GetColliderType()
    {
        return ColliderType;
    }
}
