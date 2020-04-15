using Curso.Arquitetura.Menu;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace certificacao_csharp_pt7.Aula9
{
    class DesafioConsultaXML : IExecutavel
    {

        public void Executar()
        {
            var xml = @"
                <AluraTunes>
    <Generos>
        <Genero>
            <GeneroId>1</GeneroId>
            <Nome>Rock</Nome>
        </Genero>
        <Genero>
            <GeneroId>2</GeneroId>
            <Nome>Reggae</Nome>
        </Genero>
        <Genero>
            <GeneroId>3</GeneroId>
            <Nome>Classica</Nome>
        </Genero>
    </Generos>
    <Musicas>
        <Musica>
            <MusicaId>1154</MusicaId>
            <Nome>Sweet Child O' Mine</Nome>
            <GeneroId>1</GeneroId>
            <Compositor>Guns n Roses</Compositor>
            <Milissegundos>356424</Milissegundos>
            <Bytes>5879347</Bytes>
            <PrecoUnitario>0.99</PrecoUnitario>
        </Musica>
        <Musica>
            <MusicaId>900</MusicaId>
            <Nome>I Shot The Sheriff</Nome>
            <GeneroId>2</GeneroId>
            <Compositor>Marley</Compositor>
            <Milissegundos>263862</Milissegundos>
            <Bytes>8738973</Bytes>
            <PrecoUnitario>0.99</PrecoUnitario>
        </Musica>
        <Musica>
            <MusicaId>3445</MusicaId>
            <Nome>Danubio Azul</Nome>
            <GeneroId>3</GeneroId>
            <Compositor>Johann Strauss II</Compositor>
            <Milissegundos>526696</Milissegundos>
            <Bytes>8610225</Bytes>
            <PrecoUnitario>0.99</PrecoUnitario>
        </Musica>
    </Musicas>
</AluraTunes>";

            var document = XDocument.Parse(xml);

            var relatorioMusicas = from musica in document.Element("AluraTunes").Element("Musicas").Descendants("Musica")
                                   join genero in document.Element("AluraTunes").Element("Generos").Descendants("Genero") on musica.Element("GeneroId").Value equals genero.Element("GeneroId").Value
                                   let MusicaId = musica.Element("MusicaId").Value
                                   let NomeMusica = musica.Element("Nome").Value
                                   let NomeGenero = genero.Element("Nome").Value
                                   select new { MusicaId, NomeMusica, NomeGenero };
                                   

            foreach(var item in relatorioMusicas)
            {
                Console.WriteLine($"Id da Música: {item.MusicaId} \t Nome da música: {item.NomeMusica, -040} \t Gênero: {item.NomeGenero}");
            }


        }
        
    }
}
