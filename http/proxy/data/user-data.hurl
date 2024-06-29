POST http://localhost:5274/api/app/generate-jwt-token
Cotnent-Type: application/json
{
    "UserId": "user1",
    "Roles": ["Admin", "User"]
}

HTTP 200
[Captures]
token: body

# Get user data
GET http://localhost:5274/api/data/user-data
Authorization: Bearer {{token}}
