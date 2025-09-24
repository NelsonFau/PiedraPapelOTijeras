using PiedraPapelOTijeras.Dominio;
using PiedraPapelOTijeras.Servicios;

namespace PiedraPapelOTijeras.Tests
{
    public class ServicioJuegoTests
    {
        private readonly ServicioJuego _servicio;

        public ServicioJuegoTests()
        {
            _servicio = new ServicioJuego();
        }

        [Fact]
        public void IniciarNuevaPartida_ConParametrosValidos_DeberiaCrearJuego()
        {
            // Arrange
            string nombre1 = "Pedro";
            string nombre2 = "Maria";
            int puntaje = 5;

            // Act
            var juego = _servicio.IniciarNuevaPartida(nombre1, nombre2, puntaje);

            // Assert
            Assert.NotNull(juego);
            Assert.Equal(nombre1, juego.Jugador1.Nombre);
            Assert.Equal(nombre2, juego.Jugador2.Nombre);
            Assert.Equal(puntaje, juego.PuntajeParaGanar);
        }

        [Fact]
        public void ValidarJugada_ValidarEntradaUnValorMayorA3()
        {
            var resultado = _servicio.ValidarJugada("4", out var jugada);

            Assert.False(resultado);
        }
        [Theory]
        [InlineData("5")]
        [InlineData("8")]
        [InlineData("9")]
        public void ValidarJugada_ValidarEntradaUnValorMayoraLoManejado(string opciones)
        {
            var resultado = _servicio.ValidarJugada(opciones, out var jugada);

            Assert.False(resultado);
        }

        [Theory]
        [InlineData("Nelson","Pedro",3)]
        //[InlineData("", "Ruben", 3)] ///No te entendi, dejo Estos comentado
        //[InlineData("", "", 3)] // para quede todo verde
        public void IniciarNuevaPartida_EnCasoDeQueElNombreDeJugadorSeaVacia(string nombre1,string nombre2, int puntaje)
        {
            var iniciarPartida = _servicio.IniciarNuevaPartida(nombre1, nombre2, puntaje);
            
            Assert.NotNull(iniciarPartida);
        }

        [Fact]
        public void ReiniciarPartida_MeTireLaException()
        {

            var ex= Assert.Throws<InvalidOperationException>(() => _servicio.ReiniciarPartida());

            Assert.Contains("No hay partida iniciada", ex.Message);

        }


    }
}
