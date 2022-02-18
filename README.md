# Desafio CRUD de Cliente

## Índice
- [Desafio CRUD de Cliente](#desafio-crud-de-cliente)
  - [Setup para execução](#Setup-para-execução)
- [Style Guide para desenvolvimento do back-end](#style-guide-para-desenvolvimento-do-back-end)
  - [Introdução](#introdução)
  - [Estrutura](#estrutura)

## Setup para execução
Para executar o projeto, veja as instruções [descritas aqui](Setup.md).

# Style Guide para desenvolvimento do Back-end

## Introdução
O objetivo deste documento é de definir um padrão de codificação de forma que o código em todo o 
projeto seja de fácil entendimento, independentemente de quem escreveu, e também documentar boas 
práticas de forma que novos desenvolvedores consigam rapidamente desenvolver no padrão de qualidade
esperado.

## Estrutura
As pastas principais do projeto atualmente se encontram estruturadas desta forma:
* Api - Contém controllers com rotinas da api, configurações e permissionamentos
* Contracts
  * Repositories - Contém interfaces de repositórios específicos de classes de domínio
  * Queries - Contém interface de queries
* Core
  * Abstractions - Contém dtos de request e response e também validadores de request
  * Handlers - Contém implementações de rotinas da api
* Domain - Contém classes de domínio
* IoC - Contém chamada para métodos de injeções de dependência dos projetos Data e Core
* Data
  * Database - Contém configurações do banco e migrações do projeto
  * Queries - Contém implementações de queries para serem utilizadas nas consultas. Comportamento queries busca tornar características, que muitas vezes complexas, em algo mais simples, legível, reusável e de fácil manutenção, com uma abordagem mais elegante
  * Repositories - Contém implementações dos repositórios