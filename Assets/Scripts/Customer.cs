using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour, ICollider
{
    public ColliderType ColliderType;

    private Salad mCurrentSalad;

    // Start is called before the first frame update
    void Start()
    {
        SelectSalad();
    }

    private void SelectSalad()
    {
        int numSalad = GameManager.Instance.SaladIngredientConfig.SaladData.Count;
        int selectedIndex = Random.Range(0, numSalad);

        mCurrentSalad = GameManager.Instance.SaladIngredientConfig.SaladData[selectedIndex];
    }

    public ColliderType GetColliderType()
    {
        return ColliderType;
    }

    public void ServeSalad(ServingBowl bowl)
    {
        if (mCurrentSalad.IngredientList.Count != bowl.IngredientList.Count)
        {
            OnValidateSalad(false);
            return;
        }
            

        for (int i = 0; i < bowl.IngredientList.Count; i++)
        {
            if (!mCurrentSalad.IngredientList.Contains(bowl.IngredientList[i].Type))
            {
                OnValidateSalad(false);
                return;
            }
                
        }

        OnValidateSalad(true);
    }

    private void OnValidateSalad(bool correct)
    {
        if (correct)
            Debug.Log("WOW Salad !!!!!");
        else
            Debug.Log("Seriously !!!!!");
    }
}
