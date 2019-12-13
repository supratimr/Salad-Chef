using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingBowl : MonoBehaviour
{
    public List<IngredientData> IngredientList { private set; get; }

    public void AddSalad(List<IngredientData> list)
    {
        if (IngredientList == null)
            IngredientList = new List<IngredientData>();

        IngredientList.AddRange(list);
    }
}
