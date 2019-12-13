using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    public Action OnChoppingDone;
    [SerializeField]
    private Transform mSpawn;
    [SerializeField]
    private float mChopBoardWaitDuration = 3.0f;
    [SerializeField]
    private float mObjectScaleMultiplier = 3.0f;


    public bool InUse { private set; get; }

    private IngredientData mData;
    private GameObject mCurrentObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartChopping(IngredientData data, Action callback)
    {
        InUse = true;
        mData = data;
        OnChoppingDone = callback;

        mCurrentObject = Instantiate<GameObject>(mData.MainObject, mSpawn.position, Quaternion.identity, transform);
        mCurrentObject.transform.localScale *= mObjectScaleMultiplier;
        StartCoroutine(DoChopping());
    }

    private IEnumerator DoChopping()
    {
        yield return new WaitForSeconds(mData.ChopDuration - mChopBoardWaitDuration);

        FinishChopping();
    }

    private void FinishChopping()
    {
        Destroy(mCurrentObject.gameObject);
        mCurrentObject = null;
        mCurrentObject = Instantiate<GameObject>(mData.ChoppedObject, mSpawn.position, Quaternion.identity, transform);

        StartCoroutine(ClearChoppingBoard());
    }

    private IEnumerator ClearChoppingBoard()
    {
        yield return new WaitForSeconds(mChopBoardWaitDuration);

        Destroy(mCurrentObject.gameObject);
        mCurrentObject = null;
        mData = null;
        InUse = false;

        if (OnChoppingDone != null)
        {
            OnChoppingDone();
            OnChoppingDone = null;
        }            
    }
}
