using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingBowl : MonoBehaviour
{
    private List<IngredientData> mIngredientList = new List<IngredientData>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddSalad(List<IngredientData> list)
    {
        mIngredientList = list;
    }
}
