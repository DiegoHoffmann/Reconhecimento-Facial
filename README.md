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

Como estamos trabalhando com identificação de pessoas, o modelo de aprendizado de máquina é supervisionado, ou seja, trabalhamos com imagens rotuládas para que o modelo faça o treinamento e apreenda através das caracteristicas rotular imagens ainda não utilizadas.

### Entendendo as etapas
1º - Criação do grupo para adição das pessoas. Cada grupo pode conter até 1 milhão de objetos person diferentes. 

2º - Criação da entidade Pessoa dentro do grupo. Cada pessoa objeto pode ter até 248 faces registradas.

3º - Adição das imagens da face da pessoa.

4º - Execução do treino do grupo.

5º - Identificação das faces em imagens de teste.

Abaixo a imagem exemplifica o grupo com as pessoas e suas imagens.
![image](https://user-images.githubusercontent.com/39543693/206925909-8e0713c6-de1f-4007-87f5-5534bd7b5759.png)

### Estrutura imagens
