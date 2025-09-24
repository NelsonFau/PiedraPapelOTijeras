using PiedraPapelOTijeras.Dominio;

namespace PiedraPapelOTijeras.Tests
{
    public class ResultadoRondaTests
    {
        private readonly Jugador _jugador1;
        private readonly Jugador _jugador2;

        public ResultadoRondaTests()
        {
            _jugador1 = new Jugador("Jugador1");
            _jugador2 = new Jugador("Jugador2");
        }


        [Fact]
        public void DeterminarGanador_PiedraLeGanaATijera()
        {
            var resultado = new ResultadoRonda(_jugador1, Juego.Jugada.Piedra, _jugador2, Juego.Jugada.Tijeras);

            Assert.Equal(_jugador1, resultado.Ganador);
        }

        [Fact]
        public void DeterminarGanador_PapelLeGanaAPiedra()
        {
            var resultado = new ResultadoRonda(_jugador1, Juego.Jugada.Papel, _jugador2, Juego.Jugada.Piedra);

            Assert.Equal(_jugador1, resultado.Ganador);
        }

        [Fact]
        public void DeterminarGanasor_TijeraLeGanaAPapel()
        {
            var resultado = new ResultadoRonda(_jugador1, Juego.Jugada.Tijeras, _jugador2, Juego.Jugada.Papel);
        }


        [Fact]
        public void DeterminarGanador_Empate()
        {
            var resultado = new ResultadoRonda(_jugador1, Juego.Jugada.Piedra, _jugador2, Juego.Jugada.Piedra);

            Assert.True(resultado.EsEmpate);
        }

        [Fact]
        public void GanarDescripcion_Jugador1Gana_DescripcionCorrecta()
        {
            var resultado = new ResultadoRonda(_jugador1, Juego.Jugada.Piedra, _jugador2, Juego.Jugada.Tijeras);

            Assert.Equal("Jugador1 gana: Piedra aplasta a Tijeras", resultado.Descripcion);
        }

        [Fact]
        public void GanarDescripcion_Jugador2Gana_DescripcionCorrecta()
        {
            var resultado = new ResultadoRonda(_jugador1, Juego.Jugada.Papel, _jugador2, Juego.Jugada.Tijeras);
            Assert.Equal("Jugador2 gana: Tijeras corta a Papel", resultado.Descripcion);
        }

    }
}
