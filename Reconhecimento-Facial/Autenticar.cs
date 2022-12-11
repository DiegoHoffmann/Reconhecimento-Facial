using Microsoft.Azure.CognitiveServices.Vision.Face;

namespace Reconhecimento_Facial
{
    public static class Autenticar
    {
        public static IFaceClient Obtem(string endpoint, string key)
        {
            return new FaceClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };
        }
    }
}
