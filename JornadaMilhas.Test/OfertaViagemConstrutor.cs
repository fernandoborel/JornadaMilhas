using JornadaMilhas.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemConstrutor
{
    [Theory]
    [InlineData("", null, "2025-10-07", "2025-10-15", 0, false)]
    [InlineData("OrigemTeste", "DestinoTeste", "2025-10-07", "2025-10-15", 100, true)]
    [InlineData(null, "Rio de Janeiro", "2025-10-07", "2025-10-15", -1, false)]
    [InlineData("Vitória", "São Paulo", "2025-12-01", "2025-12-10", 680, true)]
    [InlineData("Rio de Janeiro", "São Paulo", "2025-12-01", "2025-12-10", 680, true)]
    public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
    {
        //cenário - arrange
        Rota rota = new Rota(origem, destino);
        Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

        //ação - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //verificação - assert
        Assert.Equal(validacao, oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQuandoRotaNula()
    {
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2025, 10, 07), new DateTime(2025, 10, 15));
        double preco = 100.0;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }

    [Theory]
    [InlineData("", null, "2025-10-07", "2025-10-15", 0, false)]
    [InlineData("OrigemTeste", "DestinoTeste", "2025-10-07", "2025-10-15", 100, true)]
    [InlineData(null, "Rio de Janeiro", "2025-10-07", "2025-10-15", -100, false)]
    [InlineData("Vitória", "São Paulo", "2025-12-01", "2025-12-10", 680, true)]
    [InlineData("Rio de Janeiro", "São Paulo", "2025-12-01", "2025-12-10", 500, true)]
    public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorQueZero(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
    {
        //arrange
        Rota rota = new Rota(origem, destino);
        Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

        //act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //assert
        Assert.Equal(validacao, oferta.EhValido);
    }
}