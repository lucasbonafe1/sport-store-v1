# Sport Store

Aplicação de e-commerce focada em artigos esportivos, desenvolvida em .NET + Blazor com backend em API REST.
O projeto utiliza Docker Compose para orquestrar a API, UI e banco de dados.

## Build e Execução com Docker Compose
Após instalar e rodar o docker desktop ou rancher, e ter o docker instalado na maquina, execute o passo a passo:

1. Buildar containers
```bash
docker compose build
```

2. Subir containers
```bash
docker compose up -d
```

3. Verificar se estão rodando
```bash
docker ps
```

## Acessos

API Swagger → http://localhost:7150/swagger/index.html

UI Blazor → http://localhost:5000

Banco (Postgres) → localhost:5432
