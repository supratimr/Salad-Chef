using System;
using System.Collections.Generic;
using UnityEngine;

public class ServingPlate : MonoBehaviour
{
    public Action OnTrasferringDone;
    [SerializeField]
    public Transform mSpawn;
    [SerializeField]
    private float mObjectScaleMultiplier = 0.3f;
    [SerializeField]
    private float mObjectPositionMultiplier = 0.2f;

    private IngredientData mCurrentData;
    private List<IngredientData> mItemsInPlate = new List<IngredientData>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TransferToPlate(IngredientData data, Action callback)
    {
        mCurrentData = data;
        OnTrasferringDone = callback;

        mItemsInPlate.Add(data);

        GameObject obj = Instantiate<GameObject>(mCurrentData.ChoppedObject, mSpawn.position * (mItemsInPlate.Count>0?mItemsInPlate.Count:1), Quaternion.identity,transform);
        obj.transform.localPosition = Vector3.up * mObjectPositionMultiplier * (mItemsInPlate.Count > 1 ? mItemsInPlate.Count : 1);
        obj.transform.localScale *= mObjectScaleMultiplier;

        if(OnTrasferringDone != null)
        {
            OnTrasferringDone();
            OnTrasferringDone = null;
        }
    }
}
