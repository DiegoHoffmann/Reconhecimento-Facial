using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System.Reflection;

namespace Reconhecimento_Facial;
class Program
{
    static async Task Main(string[] args)
    {
        const string _personGroupId = "reconhecimento-facial";
        const string _recognitionModel = RecognitionModel.Recognition01;
        const string _keyAzure = "";
        const string _urlAzure = "https://seu-projeto.cognitiveservices.azure.com/";

        var diretorioAtual = Directory.GetCurrentDirectory();
        string nomeProjeto = Assembly.GetExecutingAssembly().GetName().Name;
        var indiceProjeto = diretorioAtual.LastIndexOf(nomeProjeto);
        string diretorioProjeto = $"{diretorioAtual.Substring(0, indiceProjeto)}{nomeProjeto}";

        IFaceClient client = Autenticar.Obtem(_urlAzure, _keyAzure);

        var personGroup = await PrepararDados.ObterGrupo(client, _personGroupId);

        if (personGroup == null)
            await PrepararDados.CriarGrupo(client, _personGroupId, _recognitionModel);

        var dicionarioPessoas = PrepararDados.CriarDicionarioPessoa(diretorioProjeto);

        await PrepararDados.CriarPessoas(client, dicionarioPessoas, _personGroupId);

        await TreinarModelo.Treinar(client, _personGroupId);

        await ReconhecimentoPelaBibliotecaAzure.Buscar(client, _personGroupId, _recognitionModel, diretorioProjeto);
    }
}

