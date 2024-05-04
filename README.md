
### Cap Produtos - Backend

  

Projeto desenvolvido na versão 6.0(LTS) do Dotnet. Tem por finalidade mostrar meu know-how na stack .NET e pode ser usado como template efetuando alguns ajustes conforme sua necessidade. 

### Pacote utilizados no Projeto

- EntityFrameworkCore
- Automapper
- Newtonsoft
- Swagger

### Estrutura das tabelas - Banco de dados

O script para gerar as tabelas se encontra na pasta `docs`

###  MER DA APLICAÇÃO
--Inserir aqui imagem do MER


### Mãos na Massa

O projeto está configurado para ser executado de dentro de um container docker, é recomendado ter ao menos o runTime do .NET 6 e Node instalado para evitar problemas, mas, a aplicação somente precisa do docker instalado na sua maquina.  

Verifique também  o `appsetting.json` localmente na sua maquina, para conferir se as variaveis da Connection string estão de acordo com seu ambiente. 

Após estes pequenos passos, e com o **DOCKER INSTALADO!**, abra um terminal na pasta raiz do back-end onde está o arquivo **docker-compose.yml** e rode o comando:

> docker-compose up

Com isto os Containers do banco, Back-end e Front-end devem subir e já estar prontos para uso!

A porta para chamar o back-end por default está na 5000, se certifique que nenhuma aplicação está rodando nesta porta antes de executar este projeto.

PRONTINHO! NESTE MOMENTO SUA APLICAÇÃO DEVE ESTAR RODANDO!

Teste executando a url no seu navegador para chamar a UI do swagger com todas as rotas do back-end!

    http://localhost:5000/swagger/index.html
