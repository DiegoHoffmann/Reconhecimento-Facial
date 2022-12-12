# Reconhecimento-Facial
Status: Em desenvolvimento.

**Objetivo:** repositório com implementação simples utilizando o serviço cognitivo da Azure para reconhecimento facial.

**Resumo:** Console aplication em .Net 6, que faz a leitura de imagens em um diretório e envia para o serviço Azure, faz o treinamento do modelo, envia imagens para teste e salva a imagem de teste com a identificação da pessoa e a acurácia da predição.

## Serviço cognitivo Microsoft Azure
O serviço de reconhecimento facial disponibilizado na Azure, fornece através de uma API algoritmos de Inteligência Artificial para análise, detecção de emoção e reconhecimento da face. Este serviço também fornece informações de atributos adicionais da face capturada.

O reconhecimento facial Azure utiliza 27 pontos de referência da face por padrão.

![image](https://user-images.githubusercontent.com/39543693/206925160-de1c0b49-e7dd-4085-a074-24cd71656ee7.png)

Para mais detalhes sobre o serviço https://learn.microsoft.com/pt-br/azure/cognitive-services/computer-vision/overview-identity
## Projeto

Será abordado dois modos de utilização do serviço de reconhecimento facial, utilizando a biblioteca *Microsoft.Azure.CognitiveServices.Vision* e através de requisições para API.

Como estamos trabalhando com identificação de pessoas, o modelo de aprendizado de máquina é supervisionado, ou seja, trabalhamos com imagens rotuladas para que o modelo faça o treinamento e apreenda através das características rotular imagens ainda não utilizadas.

### Entendendo as etapas
**1º** - Criação do grupo para adição das pessoas. Cada grupo pode conter até 1 milhão de objetos person diferentes. 

**2º** - Criação da entidade Pessoa dentro do grupo. Cada pessoa objeto pode ter até 248 faces registradas.

**3º** - Adição das imagens da face da pessoa.

**4º** - Execução do treino do grupo.

**5º** - Identificação das faces em imagens de teste.

Abaixo a imagem exemplifica o grupo com as pessoas e suas imagens.
![image](https://user-images.githubusercontent.com/39543693/206925909-8e0713c6-de1f-4007-87f5-5534bd7b5759.png)

### Estrutura imagens

**Busca** - Imagens para teste das faces enviadas

**Identificadas** - Local onde as imagens de testes serão salvas com o rótulo e a acurácia.

**Treino** - Imagens para treinamento do modelo, contem subpastas separadas por pessoas com as respectivas imagens das suas faces.


![image](https://user-images.githubusercontent.com/39543693/206928211-528d6807-74af-4a81-a7ce-9a2bbc69d5ab.png)

## Execução

Na pasta do projeto Reconhecimento-Facial onde se encontra o arquivo *Reconhecimento-Facial.sln* execute o comando abaixo:
```
dotnet build
```
Acesse a pasta Reconhecimento-Facial e execute o comando run conforme exemplo abaixo:
```
cd .\Reconhecimento-Facial\
dotnet run 
```

### Exemplo
Saída no console:

![image](https://user-images.githubusercontent.com/39543693/206940280-0ace4778-0957-485b-98b2-9a895b39fe64.png)

Imagem gerada na pasta:

![image](https://user-images.githubusercontent.com/39543693/206940691-5a7e2df0-cc22-4dc4-a2b9-32770fb3205a.png)
