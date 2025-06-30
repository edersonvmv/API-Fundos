using AutoFixture.Xunit2;
using CaseItau.Domain.DTO;
using CaseItau.Domain.Interfaces;
using CaseItau.Domain.Models;
using CaseItau.Domain.Services;
using CaseItau.Test.Attributes;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace CaseItau.Test.Domain.Services
{
    public class FundoServiceTests
    {
        [Theory]
        [AutoNSubstituteData]
        public async Task GetFundos_WhenFundosExists_ShouldReturnListOfFundos_ReturnOk([Frozen] IFundoRepository fundoRepository,
                                                                                       [Greedy] FundoService fundoService,
                                                                                       List<Fundo> fundo)
        {
            // Arrange
            fundoRepository.GetFundos().Returns(fundo);

            // Act
            var result = await fundoService.GetFundos();

            // Assert
            result.Should().BeEquivalentTo(fundo);
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task GetFundo_WhenFundoExists_ShouldReturnFundo_ReturnOk([Frozen] IFundoRepository fundoRepository,
                                                                              [Greedy] FundoService fundoService,
                                                                              ParametroIdFundoDTO idFundo,
                                                                              Fundo fundo)
        {
            // Arrange
            fundoRepository.GetFundo(idFundo).Returns(fundo);

            // Act
            var result = await fundoService.GetFundo(idFundo);

            // Assert
            result.Should().BeEquivalentTo(fundo);
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task GetFundo_WhenFundoNotExists_ShouldReturnNull_Returnfail([Frozen] IFundoRepository fundoRepository,
                                                                             [Greedy] FundoService fundoService,
                                                                             ParametroIdFundoDTO idFundo)
        {
            // Arrange
            fundoRepository.GetFundo(idFundo).Returns(null as Fundo);

            // Act
            var result = await fundoService.GetFundo(idFundo);

            // Assert
            result.Should().BeNull();

        }

        [Theory]
        [AutoNSubstituteData]
        public async Task GetFundo_WhenFundoExists_ShouldThrow_Returnfail([Frozen] IFundoRepository fundoRepository,
                                                                          [Greedy] FundoService fundoService,
                                                                          ParametroIdFundoDTO idFundo)
        {
            // Arrange
            fundoRepository.GetFundo(idFundo).Throws(new Exception("Erro"));

            // Act
            var result = await fundoService.GetFundo(idFundo);

            // Assert
            result.Should().BeEquivalentTo(new Fundo());
        }


        [Theory]
        [AutoNSubstituteData]
        public async Task PutFundo_ShouldCallRepositoryAndReturnFundo_ReturnOk([Frozen] IFundoRepository fundoRepository,
                                                                               [Greedy] FundoService fundoService,
                                                                               ParametroFundoDTO fundoFull,
                                                                               Fundo fundo)
        {
            // Arrange
            fundoRepository.GetFundo(Arg.Is<ParametroIdFundoDTO>(x => x.Codigo == fundoFull.Codigo)).Returns(fundo);

            // Act
            var result = await fundoService.PutFundo(fundoFull);

            // Assert
            result.Should().BeEquivalentTo(fundo);

            await fundoRepository.Received(1).PutFundo(fundoFull);
        }
    
        [Theory]
        [AutoNSubstituteData]
        public async Task PutPatrimonioFundo_ShouldCallRepositoryAndReturnFundo_ReturnOk([Frozen] IFundoRepository fundoRepository,
                                                                                         [Greedy] FundoService fundoService,
                                                                                         ParametroPatrimonioFundoDTO fundoFull,
                                                                                         Fundo fundo)
        {
            // Arrange
            fundoRepository.GetFundo(Arg.Is<ParametroIdFundoDTO>(x => x.Codigo == fundoFull.Codigo)).Returns(fundo);

            // Act
            var result = await fundoService.PutPatrimonioFundo(fundoFull);

            // Assert
            result.Should().BeEquivalentTo(fundo);

            await fundoRepository.Received(1).PutPatrimonioFundo(fundoFull);
        }


        [Theory]
        [AutoNSubstituteData]
        public async Task PostFundo_ShouldCallRepositoryAndReturnFundo_ReturnOk([Frozen] IFundoRepository fundoRepository,
                                                                                [Greedy] FundoService fundoService,
                                                                                ParametroFundoDTO fundoFull,
                                                                                Fundo fundo)
        {
            // Arrange
            fundoRepository.GetFundo(Arg.Is<ParametroIdFundoDTO>(x => x.Codigo == fundoFull.Codigo)).Returns(fundo);

            // Act
            var result = await fundoService.PostFundo(fundoFull);

            // Assert
            result.Should().BeEquivalentTo(fundo);

            await fundoRepository.Received(1).PostFundo(fundoFull);
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task DeleteFundo_ShouldCallRepositoryAndReturnResult_ReturnOk([Frozen] IFundoRepository fundoRepository,
                                                                                   [Greedy] FundoService fundoService,
                                                                                   ParametroIdFundoDTO idFundo)
        {
            // Arrange
            fundoRepository.DeleteFundo(idFundo).Returns(true);

            // Act
            var result = await fundoService.DeleteFundo(idFundo);

            // Assert
            result.Should().Be(true);

            await fundoRepository.Received(1).DeleteFundo(idFundo);
        }
    }
}
