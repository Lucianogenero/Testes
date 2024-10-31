using Microsoft.AspNetCore.Mvc;
using MyCompany.Application.UseCase.Fornecedor.Delete;
using MyCompany.Application.UseCase.Fornecedor.GetForId;
using MyCompany.Application.UseCase.Fornecedor.ListAll;
using MyCompany.Application.UseCase.Fornecedor.Register;
using MyCompany.Application.UseCase.Fornecedor.Update;
using MyCompany.Communication.Request;
using MyCompany.Communication.Response;
using MyCompany.Communication.Response.ResourceMessagesException;
using MyCompany.Communication.Response.ResponseErrors;

namespace MyCompany.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        /// <summary>
        /// Cadastro de Fornecedor
        /// </summary>
        /// <remarks>{"nome": "string","cnpj": "string","email": "string"}</remarks>
        /// <param name="useCase">Chamada do metodo</param>
        /// <param name="request">Json com as informações do cadastro</param>
        /// <returns>Json com os dados do cadastro mas sem ID</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Error</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseFornecedorJson),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromServices] IRegisterFornecedor useCase, [FromBody] RequestNewFornecedorJson request)
        {
            var result = await useCase.Execute(request);
            return Created(string.Empty, result);
        }

        /// <summary>
        /// Obter uma lista com todos os fornecedores
        /// </summary>
        /// <remarks> {"fornecedores": [{"id": int,"ativo": bool,"nome": string,"cnpj": string,"email": string}]},</remarks>
        /// <param name="useCase">Chamada do metodo</param>
        /// <returns>Json com todos os fornecedores</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAllFornecedor([FromServices] IListFornecedor useCase)
        {
            var result = await useCase.Execute();
            return Ok(result);
        }

        /// <summary>
        /// Obter o cadastro de um Fornecedor pelo Id
        /// </summary>
        /// <remarks>Tabela:Fornecedor field:Id </remarks>
        /// <param name="useCase">Chamada do metodo</param>
        /// <param name="Id">Id tabela Fornecedor</param>
        /// <returns>Json do cadastro do Fornecedor</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Sucesso sem conteudo</response>
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(ResponseFornecedorJson),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFornecedorId([FromServices] IGetFornecedorId useCase,[FromRoute] int Id)
        {
            var result = await useCase.Execute(Id);
            if (result == null)
                return BadRequest(new ResponseErrorJson(ResourceMessageExceptions.FORNECEDOR_NOT_FOUND));

            return Ok(result);
        }

        /// <summary>
        /// Deletar o cadastro do Fornecedor
        /// </summary>
        /// <param name="useCase">Chamada do metodo</param>
        /// <param name="Id">Id tabela Fornecedor</param>
        /// <returns>sem retorno</returns>
        /// <response code="204">Sucesso</response>
        /// <response code="400">Error List</response>
        [HttpDelete]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteFornecedor([FromServices] IDeleteFornecedor useCase,[FromRoute] int Id)
        {
            await useCase.Execute(Id);
            return NoContent();
        }


        /// <summary>
        /// Atualizar o cadastro de Fornecedor
        /// </summary>
        /// <remarks> Json: {"id": int,"ativo": bool,"nome": string,"cnpj": string,"email": string} </remarks>
        /// <param name="useCase">Chamada do metodo</param>
        /// <param name="request">Json com as informações do cadastro</param>
        /// <returns>Sem retorno</returns>
        /// <response code="202">Accepted</response>
        /// <response code="400">List Error</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateFornecedor([FromServices] IUpdateFornecedor useCase,[FromBody] RequestFornecedorJson request)
        {
            await useCase.Execute(request);
            return Accepted();
        } 

    }
}
