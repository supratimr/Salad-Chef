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
    public List<ActiveIngredientData> ItemsInPlate { private set; get; }

    // Start is called before the first frame update
    void Start()
    {
        ItemsInPlate = new List<ActiveIngredientData>();
    }

    public void TransferToPlate(IngredientData data, Action callback)
    {
        mCurrentData = data;
        OnTrasferringDone = callback;

        GameObject obj = Instantiate<GameObject>(mCurrentData.ChoppedObject, mSpawn.position * (ItemsInPlate.Count>0?ItemsInPlate.Count:1), Quaternion.identity,transform);
        obj.transform.localPosition = Vector3.up * mObjectPositionMultiplier * (ItemsInPlate.Count > 1 ? ItemsInPlate.Count : 1);
        obj.transform.localScale *= mObjectScaleMultiplier;

        ActiveIngredientData iData = new ActiveIngredientData(data, obj);
        ItemsInPlate.Add(iData);

        if (OnTrasferringDone != null)
        {
            OnTrasferringDone();
            OnTrasferringDone = null;
        }
    }

    public void Reset()
    {
        for (int Idx = 0; Idx < ItemsInPlate.Count; Idx++)
            Destroy(ItemsInPlate[Idx].GetObject());

        mCurrentData = null;
        OnTrasferringDone = null;
        ItemsInPlate.Clear();
    }
}
