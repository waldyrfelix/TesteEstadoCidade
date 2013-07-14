using System;
using EstadoCidade.Dominio;
using EstadoCidade.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace EstadoCidade.Testes
{
    [TestClass]
    public class TestesDeRepositorioDeCidade
    {
        [TestMethod]
        [TestCategory("Teste Integrado")]
        public void Obter_deve_trazer_objeto_corretamente()
        {
            // arrange
            var repositorio = new RepositorioDeCidades();

            // act
            var cidade =  repositorio.Obter(1);

            // assert 
            cidade.Should().Not.Be.Null();
            cidade.Id.Should().Be.EqualTo(1);
        }

        [TestMethod]
        [TestCategory("Teste Integrado")]
        public void Todos_deve_trazer_a_lista_completa_de_objetos_corretamente()
        {
            // arrange
            var repositorio = new RepositorioDeCidades();

            // act
            var cidades = repositorio.Todos();
            
            // assert 
            cidades.Should().Not.Be.Null();
            cidades.Should().Have.Count.EqualTo(1);
        }

        [TestMethod]
        [TestCategory("Teste Integrado")]
        public void Inserir_deve_realizar_insert_no_banco_corretamente()
        {
            // arrange
            var repositorio = new RepositorioDeCidades();
            var cidade = new Cidade("São Paulo", 2);

            // act
            repositorio.Inserir(cidade);
            
            // assert 
            var cidades = repositorio.Todos();
            cidades.Should().Not.Be.Null();
            cidades.Should().Have.Count.EqualTo(2);
        }

        [TestMethod]
        [TestCategory("Teste Integrado")]
        public void Excluir_deve_realizar_delete_no_banco_corretamente()
        {
            // arrange
            var repositorio = new RepositorioDeCidades();
            var cidade = new Cidade(1, "Recife", 1);

            // act
            repositorio.Excluir(cidade);
            
            // assert 
            var cidades = repositorio.Todos();
            cidades.Should().Not.Be.Null();
            cidades.Should().Have.Count.EqualTo(1);
        }

        [TestMethod]
        [TestCategory("Teste Integrado")]
        public void Alterar_deve_realizar_update_no_banco_corretamente()
        {
            // arrange
            var repositorio = new RepositorioDeCidades();
            var cidade = new Cidade(2, "Marília", 2);

            // act
            repositorio.Atualizar(cidade);
            
            // assert 
            var cidadeAlterada = repositorio.Obter(2);
            cidadeAlterada.Should().Not.Be.Null();
            cidadeAlterada.Nome.Should().Be.EqualTo("Marília");
        }
    }
}
