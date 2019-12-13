﻿using UnityEngine;
using System.Collections.Generic;


public class ActiveIngredientData
{
    IngredientData Data;
    GameObject Object;

    public ActiveIngredientData(IngredientData data, GameObject obj)
    {
        Data = data;
        Object = obj;
    }

    public GameObject GetObject()
    {
        return Object;
    }

    public IngredientData GetData()
    {
        return Data;
    }
}

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    

    [SerializeField]
    private string mPlayerName = string.Empty;
    [SerializeField]
    private float mSpeed = default;

    [SerializeField]
    private string mHorizontalAxis = string.Empty;
    [SerializeField]
    private string mVerticalAxis = string.Empty;
    [SerializeField]
    private string mAction = string.Empty;
    [SerializeField]
    private int mMaxPickupCount = 2;
    [SerializeField]
    private float mPickupPositionMultiplier = 1.5f;

    private CharacterController mCharController;
    private bool mAllowInput;
    private bool mInitialized;

    private Collider mCurrentCollider;
    private Queue<ActiveIngredientData> mIngredientPicked = new Queue<ActiveIngredientData>();

    void Start()
    {
        mCharController = GetComponent<CharacterController>();
        mInitialized = true;
        StopPlayerMovement(false);
    }

    public void StopPlayerMovement(bool value)
    {
        mAllowInput = !value;
    }

    void Update()
    {
        HandleInput();
    }

    public void UpdateSpeed(float speed)
    {
        mSpeed = speed;
    }

    private void HandleInput()
    {
        if (mAllowInput && mInitialized)
        {
            Vector3 displacement = new Vector3(Input.GetAxis(mHorizontalAxis), 0, Input.GetAxis(mVerticalAxis)) * mSpeed * Time.deltaTime;
            mCharController.Move(displacement);

            if (Input.GetButtonDown(mAction))
                OnPlayerInteraction();
        }
    }

    private void OnPlayerInteraction()
    {
        if (mCurrentCollider == null)
            return;

        ICollider coll = mCurrentCollider.GetComponent<ICollider>();
        ColliderType type = coll.GetColliderType();

        Debug.Log("on player action:: " + name + " ::type:: " + type);

        switch (type)
        {
            case ColliderType.IngredientPlate:
                PickupIngredient();
                break;

            case ColliderType.PrepCounter:
                DropIngredient();
                break;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        mCurrentCollider = collider;
        Debug.Log("collider enter:: " + mCurrentCollider.name);
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("collider exit:: " + collider.name);
        mCurrentCollider = null;            
    }

    private void PickupIngredient()
    {
        if (mIngredientPicked.Count >= mMaxPickupCount)
            return;

        IngredientData data = mCurrentCollider.GetComponent<IngredientPlate>().IngredientData;

        if (data.MainObject)
        {
            GameObject obj = Instantiate(data.MainObject, transform);            
            ActiveIngredientData iData = new ActiveIngredientData(data, obj);

            mIngredientPicked.Enqueue(iData);

            obj.transform.localPosition = Vector3.up * mPickupPositionMultiplier * mIngredientPicked.Count;
            obj.transform.localScale = Vector3.one * data.ScaleInUse;
        }
    }

    private void DropIngredient()
    {
        PrepCounter counter = mCurrentCollider.GetComponent<PrepCounter>();

        if(counter != null && !counter.InUse)
        {
            if (mIngredientPicked.Count > 0)
            {
                StopPlayerMovement(true);
                counter.StartPrep(mIngredientPicked.Peek().GetData(), OnPrepDone);

                ActiveIngredientData data = mIngredientPicked.Dequeue();
                Destroy(data.GetObject());

                int Idx = 1;
                foreach (ActiveIngredientData iData in mIngredientPicked.ToArray())
                {
                    iData.GetObject().transform.localPosition = Vector3.up * mPickupPositionMultiplier * Idx;
                    Idx += 1;
                }
            }
            else
                counter.TryPickup(OnPickupDone);
        }       
    }

    private void OnPrepDone()
    {
        StopPlayerMovement(false);
    }

    private void OnPickupDone(ServingBowl bowl)
    {
        if(bowl != null)
        {
            bowl.transform.parent = transform;            
        }
    }
}

