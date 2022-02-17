# Setup para desenvolvimento <!-- omit in toc -->
- [Pré-requisitos](#pré-requisitos)
- [Rodando o projeto](#rodando-o-projeto)
  - [Visual Studio](#visual-studio)
## Pré-requisitos
- Instale o Visual Studio (https://visualstudio.microsoft.com/pt-br/downloads/) 2019 ou 2022.
- Instale ou Modifique o Visual Studio (pelo Visual Studio Installer) para ter as seguintes cargas de trabalho
    - ASP.NET e desenvolvimento Web
    - Desenvolvimento entre plataformas .NET (no 2019, 2022 já vem com isso)
    - É recomendado também modificar o Visual Studio removendo o pacote de idiomas Português e adicionando o pacote em inglês por conta da baixa qualidade da tradução para Português
- (opcional, recomendado) Instale a extensão Productivity Power Tools (Extensions > Manage Extensions)
- Instale a SDK do .NET 5 (https://dotnet.microsoft.com/download/dotnet/5.0 > Installers dentro de Build Apps - SDK)
- Instale o SQL Server Express (https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) na seção "Ou faça download de uma edição especializada gratuita"
    - Importante: Na etapa "Seleção de Recursos", selecione LocalDB.
- Instale o SSMS caso não apareça a opção para instalar ao instalar o SQL Server (https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)

## Rodando o projeto

### Visual Studio
- Clique na seta para baixo Do lado do botão de play (abaixo de Window) e troque de IIS Express para ContaDigital.Api para uma execução mais rápida
- Rode o projeto!
