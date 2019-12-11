
public enum ColliderType
{
    IngredientPlate,
    PrepCounter,
    Trash,
    Customer
}

public interface ICollider
{
    ColliderType GetColliderType();
}
