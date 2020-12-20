# Usuarios
Backend Web API .NET Core para um microserviço de usuários contendo login, cadastro, geração de token seguro, recuperação de senha e testes unitários.

# API
As API's podem ser chamadas utilizando o Postman das seguintes formas

# **Criar usuario**

PUT {{url}}/api/acesso/usuario

# **Alterar usuario**

POST {{url}}/api/acesso/usuario

# **Trocar senha**

POST {{url}}/api/acesso

# **Remover usuario**

DELETE {{url}}/api/acesso/usuario

# **Obter usuarios**

GET {{url}}/api/acesso/usuario

# **Login**

POST {{url}}/api/acesso/usuario

# Authorization
A autorização de acesso foi construída utilizado o JWT (JSON Web Token), essa validação consiste na geração de um Token que contém informações de acesso e previne o acesso a rotas não autorizadas.

Para isso são utilizados 3 **Roles** de acesso, *1 - Diretor*, *2 - Gerente* e *3 - Colaborador*.

A informação do *Role* do usuário é armazenada e informada pelo campo *type* no JSON Usuario

Os métodos **Criar usuario**, **Trocar senha** e **Login** estão registrados em rota anônima, não havendo necessidade de geração de token.

O método **Obter usuarios** permite acesso pelos roles 1 - Diretor, 2 - Gerente e 3 - Colaborador.

O método **Alterar usuario** permite acesso pelos roles 1 - Diretor, 2 - Gerente.

O método **Remover usuario** permite acesso pelo role 1 - Diretor.

Para os métodos que requerem autorização é necessário incluir como *Bearer Token* o Token retornado fazer login

# JSON - Usuário
Para criação do usuário em banco e manipulação, o seguinte JSON pode ser utilizado

`{
  "id": 0,
  "name": "USUARIO DE TESTE",
  "password": "1234",
  "oldpassword": "",
  "type": 1,
  "email": "testemail@outlook.com"
}`

# Banco de dados
Para o banco de dados foi utilizado o Azure Cloud da Microsoft, afim de manter o projeto mais simples de executar e sem necessidade de preparar um ambiente com BD.

# Testes unitários
Os testes unitários encontram-se no projeto TestesUnitarios na mesma solution. Foram escritos usando *xUnit*
