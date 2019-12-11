using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
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
