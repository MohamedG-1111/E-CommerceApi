namespace E_Commerce.Services.Exceptions

{
    public abstract class NotFoundException(string Message):Exception(Message)
    {
    }
    public sealed class ProductNotFoundException(int id):NotFoundException($"Product With {id} not found") { }
    public sealed class BasketNotFoundException(string id):NotFoundException($"Basket With {id} Not Found") { }
}
