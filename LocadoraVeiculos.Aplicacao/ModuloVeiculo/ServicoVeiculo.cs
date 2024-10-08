﻿using FluentResults;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private readonly IRepositorioVeiculo repositorioVeiculo;
        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public Result<Veiculo> Inserir(Veiculo veiculo)
        {
            repositorioVeiculo.Inserir(veiculo);

            return Result.Ok(veiculo);
        }

        public Result<Veiculo> Editar(Veiculo veiculoAtualizado)
        {
            var veiculo = repositorioVeiculo.SelecionarPorId(veiculoAtualizado.Id);

            if (veiculo is null)
                return Result.Fail("O veículo não foi encontrado!");

            veiculo.Modelo = veiculoAtualizado.Modelo;
            veiculo.Marca = veiculoAtualizado.Marca;
            veiculo.Ano = veiculoAtualizado.Ano;
            veiculo.TipoCombustivel = veiculoAtualizado.TipoCombustivel;
            veiculo.GrupoVeiculoId = veiculoAtualizado.GrupoVeiculoId;

            repositorioVeiculo.Editar(veiculo);

            return Result.Ok(veiculo);
        }

        public Result<Veiculo> Excluir(int veiculoId)
        {
            var veiculo = repositorioVeiculo.SelecionarPorId(veiculoId);

            if (veiculo is null)
                return Result.Fail("O veículo não foi encontrado!");

            repositorioVeiculo.Excluir(veiculo);

            return Result.Ok(veiculo);
        }

        public Result<Veiculo> SelecionarPorId(int veiculoId)
        {
            var veiculo = repositorioVeiculo.SelecionarPorId(veiculoId);

            if (veiculo is null)
                return Result.Fail("O veículo não foi encontrado!");

            return Result.Ok(veiculo);
        }

        public Result<List<Veiculo>> SelecionarTodos()
        {
            var veiculos = repositorioVeiculo.SelecionarTodos();

            return Result.Ok(veiculos);
        }
    }
}
