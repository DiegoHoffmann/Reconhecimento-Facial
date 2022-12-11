using Microsoft.Azure.CognitiveServices.Vision.Face;
using System.Text.Json;

namespace Reconhecimento_Facial
{
    public static class ReconhecimentoPelaBibliotecaAzure
    {
        public static async Task Buscar(IFaceClient client, string personGroupId, string recognitionModel, string diretorio)
        {
            try
            {
                List<string>? imagensBusca = BuscarImagemTeste(diretorio);

                foreach (var imagem in imagensBusca)
                {
                    Stream s = File.OpenRead(imagem);
                    var detectarFaces = await client.Face.DetectWithStreamAsync(s, recognitionModel: recognitionModel);
                    var faceIds = detectarFaces.Select(face => face.FaceId.Value).ToArray();

                    if (faceIds.Count() > 0)
                    {
                        var identificacao = await client.Face.IdentifyAsync(faceIds, personGroupId);
                        var candidatos = identificacao.Where(x => x.Candidates.Any());
                        foreach(var candidato in candidatos)
                        {
                            if (candidato.Candidates.Any())
                            {
                                var pessoa = await client.PersonGroupPerson.GetAsync(personGroupId, candidato.Candidates.First().PersonId);
                                Console.WriteLine(imagem);
                                Console.WriteLine(pessoa.Name);
                                Console.WriteLine(candidato.Candidates.First().Confidence);
                                var posicao = detectarFaces.Where(x => x.FaceId.Equals(candidato.FaceId)).First().FaceRectangle;
                                Console.WriteLine(JsonSerializer.Serialize(posicao));
                                Console.WriteLine();
                                ModificarImagem.SalvarImagemFaceIdentificada(diretorio,
                                                                             imagem, 
                                                                             posicao.Width, 
                                                                             posicao.Height, 
                                                                             posicao.Top, 
                                                                             posicao.Left, 
                                                                             pessoa.Name, 
                                                                             candidato.Candidates.First().Confidence);
                            }
                        }
                    }
                    else
                        Console.WriteLine("Sem face");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static List<string>? BuscarImagemTeste(string diretorio)
        {
            List<string> imagensBusca = new List<string>();

            string caminho = $"{diretorio}\\Imagens\\Busca\\";

            DirectoryInfo directoryInfo = new DirectoryInfo(caminho);
           
            foreach (var imagem in directoryInfo.GetFiles())
            {
                imagensBusca.Add(imagem.FullName);
            }

            return imagensBusca;
        }
    }
}
