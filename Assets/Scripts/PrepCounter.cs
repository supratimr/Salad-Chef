using System;
using System.Collections.Generic;
using UnityEngine;

public class PrepCounter : MonoBehaviour, ICollider
{
    public Action OnPepDone;

    public ColliderType ColliderType;
    public ChoppingBoard ChopBoard;
    public ServingPlate ServingPlate;

    public bool InUse { private set; get; }
    private bool mRedyToServe;

    private IngredientData mData;

    // Start is called before the first frame update
    void Start()
    {
        InUse = false;        
    }

    public ColliderType GetColliderType()
    {
        return ColliderType;
    }

    public void StartPrep(IngredientData data, Action callback)
    {
        if(!InUse)
            InUse = true;
        
        mData = data;
        OnPepDone = callback;

        if (!ChopBoard.InUse)
            ChopBoard.StartChopping(mData, OnChoppingDone);
    }

    private void OnChoppingDone()
    {
        ServingPlate.TransferToPlate(mData, OnTransferDone);
    }

    private void OnTransferDone()
    {
        mData = null;
        InUse = false;
        mRedyToServe = true;

        if (OnPepDone != null)
            OnPepDone();
    }

    public void TryPickup(Action<List<IngredientData>> callback)
    {
        if(ServingPlate.ItemsInPlate.Count > 0 && callback != null)
        {
            List<IngredientData> data = new List<IngredientData>();
            for (int Idx = 0; Idx < ServingPlate.ItemsInPlate.Count; Idx++)
                data.Add(ServingPlate.ItemsInPlate[Idx].GetData());

            callback(data);
            ServingPlate.Reset();
        }
        else if (callback != null)        
            callback(null);            
    }
}
