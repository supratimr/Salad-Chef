using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepCounter : MonoBehaviour, ICollider
{
    public ColliderType ColliderType;
    public ChoppingBoard ChopBoard;
    public ServingPlate ServingBowl;

    public bool pInUse { private set; get; }

    private IngredientData mData;

    // Start is called before the first frame update
    void Start()
    {
        pInUse = false;        
    }

    public ColliderType GetColliderType()
    {
        return ColliderType;
    }

    public void StartPrep(IngredientData data)
    {
        if(!pInUse)
            pInUse = true;
        
        mData = data;

        if(!ChopBoard.pInUse)
            ChopBoard.StartChopping(mData, OnChoppingDone);
    }

    private void OnChoppingDone()
    {
        ServingBowl.TransferToPlate(mData, OnTransferDone);
    }

    private void OnTransferDone()
    {
        mData = null;
        pInUse = false;
    }
}
