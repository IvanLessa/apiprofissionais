using ControleEmpresa.Api.Models;
using ControleEmpresa.Data.Entities;
using ControleEmpresa.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEmpresa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionaisController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ProfissionaisPostModel model)
        {
            try
            {
                var profissionalRepository = new ProfissionalRepository();

                if (profissionalRepository.BuscarPorCpf(model.Cpf) != null)
                {
                    return StatusCode(400, new { mensagem = "O CPF informado já está cadastrado no sistema, tente outro." });
                }
                else if (profissionalRepository.BuscarPorEmail(model.Email) != null)
                {
                    return StatusCode(400, new { mensagem = "O Email informado já está cadastrado no sistema, tente outro." });
                }
                else if (profissionalRepository.BuscarPorTelefone(model.Telefone) != null)
                {
                    return StatusCode(400, new { mensagem = "O Telefone informado já está cadastrado no sistema, tente outro." });
                }
                else
                {
                    var profissional = new Profissional()
                    {
                        IdProfissional = Guid.NewGuid(),
                        Nome = model.Nome,
                        Email = model.Email,
                        Cpf = model.Cpf,
                        Telefone = model.Telefone,
                        DataCadastro = DateTime.Now                        
                    };

                    profissionalRepository.Cadastrar(profissional);

                    return StatusCode(201, new { mensagem = $"{profissional.Nome} foi cadastrado(a) com sucesso." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }


        }

        [HttpPut]
        public IActionResult Put(ProfissionaisPutModel model)
        {
            try
            {
                var profissionalRepository = new ProfissionalRepository();
                var profissional = profissionalRepository.BuscarPorId(model.IdProfissional);

                if (profissional == null)
                {
                    return StatusCode(400, new { mensagem = "Profissional não encontrado, verifique o ID informado." });
                }
                else                
                {
                    profissional.Nome = model.Nome;
                    profissional.Email = model.Email;
                    profissional.Cpf = model.Cpf;
                    profissional.Telefone = model.Telefone;
                }

                profissionalRepository.Editar(profissional);

                return StatusCode(200, new { mensgame = "Profissional atualizado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
        
        [HttpDelete ("{idProfissional}")]
        public IActionResult Delete(Guid idProfissional)
            {
            try
            {
                var profissionalRepository = new ProfissionalRepository();
                var profissional = profissionalRepository.BuscarPorId(idProfissional);

                if (profissional != null)
                {
                    profissionalRepository.Apagar(profissional);
                    return StatusCode(200, new { mensagem = "Cadastro excluído com sucesso." });
                }
                else
                {
                    return StatusCode(400,new {mensagem = "Cadastro não encontrado, verifique o ID informado." });
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Erro ao apagar dados: {e.Message}" });
            }
        }
       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProfissionaisGetModel>))]
        public IActionResult GetAll()
        {
            try
            {
                var lista = new List<ProfissionaisGetModel>();
                
                var profissionalRepository = new ProfissionalRepository();
                foreach (var item in profissionalRepository.BuscarTodos())
                {
                    var model = new ProfissionaisGetModel()
                    {
                        IdProfissional = item.IdProfissional,
                        Nome = item.Nome,
                        Email = item.Email,
                        Cpf = item.Cpf,
                        Telefone = item.Telefone,
                        DataCadastro = item.DataCadastro,
                    };
                    lista.Add(model);
                }

                return StatusCode(200, lista);                

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Erro ao pesquisar: {e.Message}" });
            }


            return Ok();
        }


        [HttpGet ("{idProfissional}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfissionaisGetModel))]
        public IActionResult Get(Guid idProfissional)
        {
            try
            {
                var profissionalRepository = new ProfissionalRepository(); ;
                var profissional = profissionalRepository.BuscarPorId(idProfissional);

                if (profissional != null)
                {
                    var model = new ProfissionaisGetModel()
                    {
                        IdProfissional = profissional.IdProfissional,
                        Nome = profissional.Nome,
                        Email = profissional.Email,
                        Telefone = profissional.Telefone,
                        Cpf = profissional.Cpf,
                        DataCadastro = profissional.DataCadastro
                    };

                    return StatusCode(200, model);
                }
                else
                {
                    return StatusCode(204);
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Erro ao pesquisar: {e.Message}" });
            }

        }
    }
}
