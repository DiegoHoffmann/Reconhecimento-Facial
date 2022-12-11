using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System.Reflection;

namespace Reconhecimento_Facial
{
    public static class PrepararDados
    {
        public static Dictionary<string, string[]> CriarDicionarioPessoa(string diretorio)
        {
            Dictionary<string, string[]> personDictionary = new Dictionary<string, string[]>();

            string caminho = $"{diretorio}\\Imagens\\Treino";

            DirectoryInfo directoryInfo = new DirectoryInfo(caminho);
            foreach (var pasta in directoryInfo.GetDirectories()) 
            {
                DirectoryInfo directoryInfoPasta = new DirectoryInfo(pasta.FullName);
                foreach (var img in directoryInfoPasta.GetFiles())
                {
                    if (!personDictionary.ContainsKey(directoryInfoPasta.Name))
                    {
                        var lst_img = directoryInfoPasta.GetFiles().Where(x => x.Name.Contains(directoryInfoPasta.Name));
                        List<string> lstString = new List<string>();
                        lst_img.ToList().ForEach(x => { lstString.Add(x.FullName); });
                        personDictionary.Add(directoryInfoPasta.Name, lstString.ToArray());
                    }
                }
            }

            return personDictionary;
        }

        public static async Task<PersonGroup> ObterGrupo(IFaceClient client, string personGrupo)
        {
            try
            {
                var result = await client.PersonGroup.GetAsync(personGrupo, returnRecognitionModel: true);
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static async Task CriarGrupo(IFaceClient client, string personGrupo, string recognitionModel)
        {
            try
            {
                await client.PersonGroup.CreateAsync(personGrupo, personGrupo, recognitionModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static async Task CriarPessoas(IFaceClient client, Dictionary<string, string[]> dicionarioPessoas, string personGroupId)
        {
            foreach (var groupedFace in dicionarioPessoas.Keys)
            {
                Person person = await client.PersonGroupPerson.CreateAsync(personGroupId: personGroupId, name: groupedFace);

                foreach (var imagem in dicionarioPessoas[groupedFace])
                {
                    try
                    {
                        Stream s = File.OpenRead(imagem);
                        PersistedFace face = await client.PersonGroupPerson.AddFaceFromStreamAsync(personGroupId, person.PersonId, s, detectionModel: DetectionModel.Detection01);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
