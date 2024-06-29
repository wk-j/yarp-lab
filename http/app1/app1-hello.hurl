POST http://localhost:8080/api/app/generate-jwt-token
Cotnent-Type: application/json
{
    "UserId": "user1",
    "Roles": ["Admin", "User"]
}

HTTP 200
[Captures]
token: body

# hello
GET http://localhost:8080/app1/api/app1/hello
Authorization: Bearer {{token}}
