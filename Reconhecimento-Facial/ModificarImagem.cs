using System.Drawing;
using System.Reflection;

namespace Reconhecimento_Facial
{
    public static class ModificarImagem
    {
        public static void SalvarImagemFaceIdentificada(string diretorio, string imagem, int largura, int altura, int topo, int esquerda,string nome, double acurancia)
        {
            var retangulo = new Rectangle(esquerda, topo, largura, altura);
            Image image1 = Image.FromFile(imagem);
            Graphics graphics = Graphics.FromImage(image1);
            var borda = new Pen(Color.Red, 2);
            graphics.DrawRectangle(borda, retangulo);

            var fonte = new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Bold);
            var pintar = new SolidBrush(Color.Red);
            graphics.DrawString(nome, fonte, pintar, new PointF(esquerda, topo - 16f));
            graphics.DrawString(acurancia.ToString(), fonte, pintar, new PointF(esquerda, topo + altura));
            graphics.Save();

            string caminho = $"{diretorio}\\Imagens\\Identificadas";

            string novaImagem = $"{caminho}\\{imagem.Substring(imagem.LastIndexOf("\\"))}";
            image1.Save(novaImagem);
        }
    }
}
