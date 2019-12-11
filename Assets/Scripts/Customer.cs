using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour, ICollider
{
    public ColliderType ColliderType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public ColliderType GetColliderType()
    {
        return ColliderType;
    }
}
