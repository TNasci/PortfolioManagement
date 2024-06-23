#!/bin/bash

# Definir as variáveis necessárias
PROJECT_DIR=$(dirname "$0")
PROJECT_FILE="$PROJECT_DIR/PortfolioManagement.csproj"
DB_NAME="PortfolioManagement"
MIGRATION_NAME="InitialCreate"

# Função para exibir mensagens
function info {
    echo -e "\033[1;34m[INFO]\033[0m $1"
}

# Função para exibir erros
function error {
    echo -e "\033[1;31m[ERROR]\033[0m $1"
}

# Verificar se o .NET SDK está instalado
if ! command -v dotnet &> /dev/null
then
    error "O .NET SDK não está instalado. Por favor, instale o .NET SDK primeiro."
    exit 1
fi

# Verificar se o arquivo .csproj existe
if [ ! -f "$PROJECT_FILE" ]; then
    error "Arquivo .csproj não encontrado. Execute este script no diretório raiz do projeto."
    exit 1
fi

# Restaurar dependências do projeto
info "Restaurando dependências do projeto..."
dotnet restore "$PROJECT_FILE"

if [ $? -ne 0 ]; then
    error "Falha ao restaurar dependências do projeto."
    exit 1
fi

# Criar as migrações e aplicar ao banco de dados
info "Criando e aplicando migrações ao banco de dados..."

# Remover quaisquer migrações anteriores
dotnet ef migrations remove -p "$PROJECT_FILE" -s "$PROJECT_FILE" -f

# Adicionar nova migração
dotnet ef migrations add "$MIGRATION_NAME" -p "$PROJECT_FILE" -s "$PROJECT_FILE"

if [ $? -ne 0 ]; then
    error "Falha ao criar a migração."
    exit 1
fi

# Aplicar a migração ao banco de dados
dotnet ef database update -p "$PROJECT_FILE" -s "$PROJECT_FILE"

if [ $? -ne 0 ]; then
    error "Falha ao aplicar a migração ao banco de dados."
    exit 1
fi

# Informar o sucesso da operação
info "Dependências instaladas e banco de dados configurado com sucesso!"
