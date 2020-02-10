using ASPNetCoreReactRedux_Persons.Data.Repository;
using ASPNetCoreReactRedux_Persons.DTO;
using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Services
{
    public class PessoaServices : IPessoaServices
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ILogger _logger;

        public PessoaServices(IPessoaRepository pessoaRepository, ILoggerFactory loggerFactory)
        {
            _pessoaRepository = pessoaRepository;
            _logger = loggerFactory.CreateLogger("PessoaServices");
        }

        public async Task<List<PessoaDTO>> GetPessoasAsync()
        {
            return (await _pessoaRepository.GetPessoasAsync()).ToListDTO();
        }

        public async Task<PessoaDTO> GetPessoaAsync(long id)
        {
            return (await _pessoaRepository.GetPessoaAsync(id)).ToDTO();
        }

        public async Task<PessoaDTO> InsertPessoaAsync(PessoaDTO pessoa)
        {
            var listaIdioma = new List<PessoaIdioma>();
            var listaRelacionamento = new List<Relacionamento>();
            var listaDocumento = new List<Documento>();
            if (!string.IsNullOrEmpty(pessoa.CPF))
            {
                listaDocumento.Add(
                    new Documento
                    {
                        NumeroDocumento = pessoa.CPF,
                        TipoDocumentoId = Entity.Enum.EnumTipoDocumento.CPF
                    });
            }
            if (!string.IsNullOrEmpty(pessoa.RG))
            {
                listaDocumento.Add(
                new Documento
                {
                    NumeroDocumento = pessoa.RG,
                    TipoDocumentoId = Entity.Enum.EnumTipoDocumento.RG
                });
            }
            if (pessoa.Documentos != null)
            {
                foreach (var item in pessoa.Documentos)
                {
                    listaDocumento.Add(new Documento
                    {
                        NumeroDocumento = item.Documento,
                        TipoDocumentoId = (Entity.Enum.EnumTipoDocumento)item.TipoDocumentoId
                    });
                }
            }
            if (pessoa.Idiomas != null)
            {
                foreach (var item in pessoa.Idiomas)
                {
                    listaIdioma.Add(new PessoaIdioma
                    {
                        IdiomaId = (Entity.Enum.EnumIdioma)item.IdIdioma
                    });
                }
            }
            if (pessoa.Relacionamentos != null)
            {
                foreach (var item in pessoa.Relacionamentos)
                {
                    listaRelacionamento.Add(new Relacionamento
                    {
                        PessoaRelacionadaId = item.PessoaRelacionadaId,
                        TipoRelacionamentoId = (Entity.Enum.EnumTipoRelacionamento)item.PessoaRelacionadaId
                    });
                }
            }

            var oPessoa = new Pessoa
            {
                Nome = pessoa.Nome,
                SobreNome = pessoa.SobreNome,
                Pseudonimo = pessoa.Pseudonimo,
                Sexo = pessoa.Sexo.ToLower() == "masculino",
                DataNascimento = pessoa.DataNascimento,
                Endereco = new Endereco
                {
                    TipoEnderecoId = (Entity.Enum.EnumTipoEndereco)pessoa.Endereco.TipoEnderecoId,
                    Logradouro = pessoa.Endereco.Logradouro,
                    Numero = pessoa.Endereco.Numero,
                    Bairro = pessoa.Endereco.Bairro,
                    CEP = pessoa.Endereco.Cep,
                    CidadeId = pessoa.Endereco.CidadeId
                },
                Celular = new Contato
                {
                    Descricao = pessoa.Celular,
                    TipoContatoId = Entity.Enum.EnumTipoContato.Celular
                },
                Email = new Contato
                {
                    Descricao = pessoa.Email,
                    TipoContatoId = Entity.Enum.EnumTipoContato.Email
                },
                Documentos = listaDocumento,
                Idiomas = listaIdioma,
                Relacionamentos = listaRelacionamento
            };

            _pessoaRepository.Add(oPessoa);
            try
            {
                await _pessoaRepository.SaveChangesAsync();

                pessoa = (await _pessoaRepository.GetPessoaAsync(oPessoa.PessoaId)).ToDTO();
            }
            catch (System.Exception exp)
            {
                _logger.LogError($"Error in {nameof(InsertPessoaAsync)}: " + exp.Message);
            }

            return pessoa;
        }

        public async Task<bool> UpdatePessoaAsync(PessoaDTO pessoa)
        {
            var oPessoa = await _pessoaRepository.GetPessoaAsync(pessoa.PessoaId);
            var listaDocumento = oPessoa.Documentos;
            var listaRelacionamento = oPessoa.Relacionamentos;

            if (pessoa.Idiomas.Count > 0)
            {
                var listaIdioma = new List<PessoaIdioma>();

                foreach (var item in pessoa.Idiomas)
                {
                    listaIdioma.Add(new PessoaIdioma
                    {
                        IdiomaId = (Entity.Enum.EnumIdioma)item.IdIdioma
                    });
                }

                oPessoa.Idiomas = listaIdioma;
            }

            oPessoa.Nome = pessoa.Nome;
            oPessoa.SobreNome = pessoa.SobreNome;
            oPessoa.Pseudonimo = pessoa.Pseudonimo;
            oPessoa.Sexo = pessoa.Sexo.ToLower() == "masculino";
            oPessoa.DataNascimento = pessoa.DataNascimento;
            oPessoa.Endereco = new Endereco
            {
                EnderecoId = oPessoa.EnderecoId,
                TipoEnderecoId = (Entity.Enum.EnumTipoEndereco)pessoa.Endereco.TipoEnderecoId,
                Logradouro = pessoa.Endereco.Logradouro,
                Numero = pessoa.Endereco.Numero,
                Bairro = pessoa.Endereco.Bairro,
                CEP = pessoa.Endereco.Cep,
                CidadeId = pessoa.Endereco.CidadeId
            };
            oPessoa.Celular = new Contato
            {
                Descricao = pessoa.Celular,
                TipoContatoId = Entity.Enum.EnumTipoContato.Celular
            };
            oPessoa.Email = new Contato
            {
                Descricao = pessoa.Email,
                TipoContatoId = Entity.Enum.EnumTipoContato.Email
            };

            foreach (var item in pessoa.Documentos)
            {
                var oDocumento = oPessoa.Documentos.FirstOrDefault(w => (int)w.TipoDocumentoId == item.TipoDocumentoId);
                if (oDocumento != null)
                {
                    listaDocumento.Add(new Documento
                    {
                        DocumentoId = oDocumento.DocumentoId,
                        NumeroDocumento = item.Documento,
                        TipoDocumentoId = (Entity.Enum.EnumTipoDocumento)item.TipoDocumentoId
                    });
                }
                else
                {
                    listaDocumento.Add(new Documento
                    {
                        NumeroDocumento = item.Documento,
                        TipoDocumentoId = (Entity.Enum.EnumTipoDocumento)item.TipoDocumentoId
                    });
                }
            }

            foreach (var item in pessoa.Relacionamentos)
            {
                var oRelacionamento = oPessoa.Relacionamentos.FirstOrDefault(w => (int)w.PessoaRelacionadaId == item.PessoaRelacionadaId);

                if (oRelacionamento != null)
                {
                    listaRelacionamento.Remove(oRelacionamento);
                }
                listaRelacionamento.Add(new Relacionamento
                {
                    PessoaPropriaId = oPessoa.PessoaId,
                    PessoaRelacionadaId = item.PessoaRelacionadaId,
                    TipoRelacionamentoId = (Entity.Enum.EnumTipoRelacionamento)item.PessoaRelacionadaId
                });
            }

            oPessoa.Documentos = listaDocumento;
            oPessoa.Relacionamentos = listaRelacionamento;

            _pessoaRepository.Update(oPessoa);
            try
            {
                return (await _pessoaRepository.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _logger.LogError($"Error in {nameof(UpdatePessoaAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<bool> DeletePessoaAsync(long id)
        {
            var oPessoa = await _pessoaRepository.GetPessoaAsync(id);
            _pessoaRepository.Delete(oPessoa);
            try
            {
                return (await _pessoaRepository.SaveChangesAsync() > 0 ? true : false);
            }
            catch (System.Exception exp)
            {
                _logger.LogError($"Error in {nameof(DeletePessoaAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<bool> DeletePessosAsync(long[] id)
        {
            var listaPessoa = await _pessoaRepository.GetPessoasAsync(id);
            _pessoaRepository.DeleteList(listaPessoa);
            try
            {
                return (await _pessoaRepository.SaveChangesAsync() > 0 ? true : false);
            }
            catch (System.Exception exp)
            {
                _logger.LogError($"Error in {nameof(DeletePessoaAsync)}: " + exp.Message);
            }
            return false;
        }

    }
}
