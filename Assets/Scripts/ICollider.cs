
public enum ColliderType
{
    IngredientPlate,
    ChoppingBoard,
    Trash,
    Customer
}

public interface ICollider
{
    ColliderType GetColliderType();
}
