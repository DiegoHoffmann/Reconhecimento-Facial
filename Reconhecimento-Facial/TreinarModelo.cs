using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace Reconhecimento_Facial
{
    public static class TreinarModelo
    {
        public static async Task Treinar(IFaceClient client, string personGroupId)
        {
            Console.WriteLine("Iniciando Treinamento");
            await client.PersonGroup.TrainAsync(personGroupId);

            while (true)
            {
                await Task.Delay(1000);
                var trainingStatus = await client.PersonGroup.GetTrainingStatusAsync(personGroupId);
                Console.Write('-');
                if (trainingStatus.Status == TrainingStatusType.Succeeded) { break; }

            }
            Console.WriteLine("Treinamento Finalizado");
        }
    }
}
