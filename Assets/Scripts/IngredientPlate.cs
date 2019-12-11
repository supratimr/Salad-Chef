using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientPlate : MonoBehaviour, ICollider
{
    public IngredientTypes Ingredient;
    public ColliderType ColliderType;
    public Transform IngredientSpawn;

    private IngredientData mIngredientData;
    public IngredientData IngredientData { get { return mIngredientData; } }
    private GameObject mIngredientObj;

   
    void Start()
    {
        if(GameManager.Instance != null && GameManager.Instance.SaladIngredientConfig != null)
            mIngredientData = GameManager.Instance.SaladIngredientConfig.IngredientData.Find(s => s.Type == Ingredient);

        if (mIngredientData != null)
            InitIngredient();
    }

    private void InitIngredient()
    {
        mIngredientObj = GameObject.Instantiate(mIngredientData.MainObject, IngredientSpawn.position, Quaternion.identity, transform);
    }

    public ColliderType GetColliderType()
    {
        return ColliderType;
    }
}
