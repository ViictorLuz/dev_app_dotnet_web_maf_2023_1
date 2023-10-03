
# Projeto - Cadastrando Professores e Alunos

Projeto de cadastro de professores e alunos, do curso de back-end com .NET da instituição SENAC onde desenvolvemos aplicações back-end para web utilizando a plataforma .NET da Microsoft, assim como a configuração do ambiente de trabalho, a aplicabilidade de banco de dados em sistemas back-end e o empacotamento de um sistema. 

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ViictorLuz/dev_app_dotnet_web_maf_2023_1/blob/master/LICENSE.txt)

## Documentação da API

#### Retorna todos os itens

### Aluno Controller
#### Retorna a lista de alunos

```http
  GET /api/aluno
```

### Professor Controller
#### Retorna a lista de professores

```http
  GET /api/professor/lista
```
#### Retorna uma lista de professores filtrando pelo nome

```http
  GET /api/professor/busca?nome={nome}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `nome`      | `string` | **Obrigatório**. O NOME do professor que você quer |


## Docente
- [@lpjunior](https://www.github.com/lpjunior)

## Aluno
- [@ViictorLuz](https://www.github.com/ViictorLuz)  
  
  [![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/victor-hugo-luz)
## Conhecimentos adquiridos
 - Configurar ambiente de desenvolvimento.
 - Criar estruturas de código utilizando linguagem para back-end.
 - Implementar session e cookies da aplicação web.
 - Integrar banco de dados, de acordo com a aplicação web.
 - Gerar os pacotes da aplicação web.
 ## Referência

 - [.Net](https://learn.microsoft.com/pt-br/dotnet/)
 - [REST](https://restfulapi.net)
 - [JSON](https://restfulapi.net/introduction-to-json/)

