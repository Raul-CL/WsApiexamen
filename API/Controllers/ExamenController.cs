using ApiExamenDatos;
using Dominio.DTO;
using Dominio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WsApiExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : ControllerBase
    {
        private readonly Contexto _context;
        private readonly RespuestaDTO respuesta;

        public ExamenController(Contexto contexto)
        {
            this._context = contexto;
            this.respuesta = new RespuestaDTO();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarExamen([FromBody] Examen examen, bool metodo)
        {
            if(examen == null)
            {
                return BadRequest("Examen no puede ser nulo");
            }

            if(metodo)
            {
                _context.tblExamen.Add(examen);
                await _context.SaveChangesAsync();
                return Ok(examen);
            }
            else
            {                
                var nombreParam = new SqlParameter("@Nombre", SqlDbType.VarChar, 255) { Value = examen.Nombre };
                var descripcionParam = new SqlParameter("@Descripcion", SqlDbType.VarChar, 255) { Value = examen.Descripcion };
                var codigoRetorno = new SqlParameter("@CodigoRetorno", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var mensajeRetorno = new SqlParameter("@Mensaje", SqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };

                await _context.Database.ExecuteSqlRawAsync("EXEC dbo.spAgregar @Nombre, @Descripcion, @CodigoRetorno OUTPUT, @Mensaje OUTPUT",
                    nombreParam, descripcionParam, codigoRetorno, mensajeRetorno);

                respuesta.EsExitoso = (int)codigoRetorno.Value == 0;
                respuesta.Mensaje = mensajeRetorno.Value.ToString();
                respuesta.Resultado = examen;

                return Ok(respuesta);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarExamen([FromBody] Examen examenParam, bool metodo)
        {
            var examen = await _context.tblExamen.FindAsync(examenParam.IdExamen);
            if (examen == null) 
            {
                return NotFound("Examen no encontrado");
            }

            if (metodo)
            {
                _context.Update(examen);
                await _context.SaveChangesAsync();

                return Ok(examen);
            }
            else
            {
                var idExamenParam = new SqlParameter("@IdExamen", SqlDbType.Int) { Value = examenParam.IdExamen };
                var nombreParam = new SqlParameter("@Nombre", SqlDbType.VarChar, 255) { Value = examenParam.Nombre};
                var descripcionParam = new SqlParameter("@Descripcion", SqlDbType.VarChar, 255) { Value = examenParam.Descripcion };
                var codigoRetorno = new SqlParameter("@CodigoRetorno", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var mensajeRetorno = new SqlParameter("@Mensaje", SqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };

                await _context.Database.ExecuteSqlRawAsync("EXEC dbo.spActualizar @IdExamen, @Nombre, @Descripcion, @CodigoRetorno OUTPUT, @Mensaje OUTPUT",
                    idExamenParam, nombreParam, descripcionParam, codigoRetorno, mensajeRetorno);

                respuesta.EsExitoso = (int)codigoRetorno.Value == 0;
                respuesta.Mensaje = mensajeRetorno.Value.ToString();
                respuesta.Resultado = examen;

                return Ok(respuesta.EsExitoso);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarExamen(int idExamen, bool metodo)
        {            
            var examen = await _context.tblExamen.FindAsync(idExamen);

            if(examen == null)
            {
                return NotFound("Examen no encontrado");
            }

            if (metodo)
            {
                _context.tblExamen.Remove(examen);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                var idExamenParam = new SqlParameter("@IdExamen", SqlDbType.Int) { Value = idExamen };
                var codigoRetorno = new SqlParameter("@CodigoRetorno", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var mensajeRetorno = new SqlParameter("@Mensaje", SqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };

                var response = await _context.Database.ExecuteSqlRawAsync("EXEC dbo.spEliminar @IdExamen, @CodigoRetorno OUTPUT, @Mensaje OUTPUT",
                    idExamenParam, codigoRetorno, mensajeRetorno);

                respuesta.EsExitoso = (int)codigoRetorno.Value == 0;
                respuesta.Mensaje = mensajeRetorno.Value.ToString();                                

                return Ok(respuesta.EsExitoso);
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarExamen(string nombre, string descripcion, bool metodo)
        {                       
            if (metodo)
            {
                respuesta.Resultado= await _context.tblExamen.Where(t => t.Nombre == nombre 
                    && t.Descripcion == descripcion)
                    .ToListAsync();
                                
                return Ok(respuesta.Resultado);
                
            }
            else
            {                                
                respuesta.Resultado = await _context.tblExamen
                .FromSqlInterpolated($"EXECUTE dbo.spConsultar {nombre}, {descripcion}")
                .ToListAsync();

                return Ok(respuesta.Resultado);
            }                        
        }
    }
}
