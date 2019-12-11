using System.Collections.Generic;
using UnityEngine;


    public enum IngredientTypes
    {
        Cucumber,
        Tomato,
        Broccoli,
        Carrot,
        Avocado,
        Apple
    }

    [System.Serializable]
    public class IngredientData
    {
        public IngredientTypes Type;
        public string DisplayName;
        public GameObject MainObject;
        public GameObject ChoppedObject;
        public float ScaleInUse = 1f;
        public Sprite Icon;
        public float ChopDuration;
    }

    [System.Serializable]
    public class Salad
    {
        public string SaladName;
        public Sprite Icon;
        public int Cost = 10;
        public List<IngredientTypes> IngredientList = new List<IngredientTypes>();
    }

    [CreateAssetMenu(fileName = "SaladIngredientConfig", menuName = "Config/SaladIngredientConfig", order = 1)]
    public class SaladIngredientConfig: ScriptableObject
    {
    public List<IngredientData> IngredientData = new List<IngredientData>();
        public List<Salad> SaladData = new List<Salad>();
    }

