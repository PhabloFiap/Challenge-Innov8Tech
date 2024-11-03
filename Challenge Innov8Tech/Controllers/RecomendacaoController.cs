using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace Challenge_Innov8Tech.Controllers
{
    public class DadosRecomendacao
    {
        [LoadColumn(0)] public int ClienteId { get; set; }
        [LoadColumn(1)] public string Nome { get; set; }
        [LoadColumn(2)] public int Cpf { get; set; }
        [LoadColumn(3)] public string Email { get; set; }
        [LoadColumn(4)] public string Telefone { get; set; }
        [LoadColumn(5)] public int RamoId { get; set; }
        [LoadColumn(6)] public string RamoNome { get; set; }
        [LoadColumn(7)] public string DescricaoRamo { get; set; }
        [LoadColumn(8)] public float Label { get; set; }
    }

    public class RecomendacaoProduto
    {
        [ColumnName("Score")]
        public float PontuacaoRecomendacao { get; set; }
        [ColumnName("RamoNome")]
        public string RamoNome { get; set; } = string.Empty;
    }


    [Route("api/[controller]")]
    [ApiController]
    public class RecomendacaoController : ControllerBase
    {
        private readonly string caminhoModelo = Path.Combine(Environment.CurrentDirectory, "wwwroot", "MLModels", "ModeloRecomendacao.zip");
        private readonly string caminhoTreinamento = Path.Combine(Environment.CurrentDirectory, "Data", "fictitious_client_data_no_address.csv");
        private readonly MLContext mlContext;

        public RecomendacaoController()
        {
            mlContext = new MLContext();

            if (!System.IO.File.Exists(caminhoModelo))
            {
                Console.WriteLine("Modelo não encontrado. Iniciando treinamento...");
                TreinarModelo();
            }
        }

        //Metodo para verificar se o produto é ou nao recomendado baseado na entrada de CPF e Produto
        [HttpGet("recomendar/{nome}/{RamoNome}")]
        public IActionResult Recomendar(string nome, string ramoNome)
        {
            if (!System.IO.File.Exists(caminhoModelo))
            {
                return BadRequest("O modelo ainda não foi treinado.");
            }

            ITransformer modelo;
            using (var stream = new FileStream(caminhoModelo, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                modelo = mlContext.Model.Load(stream, out var modeloSchema);
            }

            var engineRecomendacao = mlContext.Model.CreatePredictionEngine<DadosRecomendacao, RecomendacaoProduto>(modelo);

            var recomendacao = engineRecomendacao.Predict(new DadosRecomendacao
            {
                Nome = nome,
                RamoNome = ramoNome
                
            });

            return Ok(new
            {
              
                recomendacao = GetStatusRecomendacao(recomendacao.PontuacaoRecomendacao)
            });
        }



        private void TreinarModelo()
        {
            var pastaModelo = Path.GetDirectoryName(caminhoModelo);
            if (!Directory.Exists(pastaModelo))
            {
                Directory.CreateDirectory(pastaModelo);
                Console.WriteLine($"Diretório criado: {pastaModelo}");
            }

            IDataView dadosTreinamento = mlContext.Data.LoadFromTextFile<DadosRecomendacao>(
                 path: caminhoTreinamento, hasHeader: true, separatorChar: ',');

            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(DadosRecomendacao.Label))
    .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "CPFCodificado", inputColumnName: nameof(DadosRecomendacao.Cpf)))
    .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "EmailCodificado", inputColumnName: nameof(DadosRecomendacao.Email)))
    .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "TelefonelCodificado", inputColumnName: nameof(DadosRecomendacao.Telefone)))
    .Append(mlContext.Transforms.Concatenate("Features", "CPFCodificado", "EmailCodificado", "TelefonelCodificado"))
    .Append(mlContext.Regression.Trainers.FastTree());


            var modelo = pipeline.Fit(dadosTreinamento);

            mlContext.Model.Save(modelo, dadosTreinamento.Schema, caminhoModelo);
            Console.WriteLine($"Modelo treinado e salvo em: {caminhoModelo}");
       
        
        
        
        
        
        }
        private string GetStatusRecomendacao(float pontuacao)
        {
            switch (Math.Round(pontuacao, 1))
            {
                case >= 4:
                    return "Altamente Recomendado";
                case >= 3:
                    return "Recomendado";
                default:
                    return "Recomendado";
            }
        }



    }
}
