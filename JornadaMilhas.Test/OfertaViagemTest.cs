using JornadaMilhas.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemTest
{
    [Fact]
    public void TestandoOfertaValida()
    {
        //cenário - arrange
        Rota rota = new Rota("OrigemTeste", "Destino");
        Periodo periodo = new Periodo(new DateTime(2025, 10, 07), new DateTime(2025, 10, 15));
        double preco = 100.0;
        var validacao = true;

        //ação - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //verificação - assert
        Assert.Equal(validacao, oferta.EhValido);
    }

    [Fact]
    public void TestandoOfertaComRotaNula()
    {
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2025, 10, 07), new DateTime(2025, 10, 15));
        double preco = 100.0;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }
}