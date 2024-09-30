# OrderServiceApp API

CRUD HardCode OrderService
- **ASP.NET 8**: 
- **Entity Framework Core**:
- **Postman**: 
- **JSON**:
- **PostgreSQL**:

## Модель `Order`

```json
{
  "id": int,
  "name": string,
  "description": string
}
```

## Эндпойнты
```
  /api/orders
```
1.  GET     `/api/orders`
2.  GET(id)     `/api/orders/{id}`
3.  POST    `/api/orders`
4.  PUT     `/api/orders/{id}`
5.  DELETE  `/api/orders/{id}`
