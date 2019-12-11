using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepCounter : MonoBehaviour, ICollider
{
    public ColliderType ColliderType;
    public GameObject ChopBoard;
    public GameObject ServingBowl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public ColliderType GetColliderType()
    {
        return ColliderType;
    }
}
