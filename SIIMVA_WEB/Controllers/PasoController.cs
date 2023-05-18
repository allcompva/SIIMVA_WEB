using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;
using MOTOR_WORKFLOW.Entities;
using System;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PasoController : ControllerBase
    {
        private readonly IWebHostEnvironment _HostEnvironment;
        private IPasoService _PasoService;
        public PasoController(IPasoService PasoService, IWebHostEnvironment hostEnvironment)
        {
            _PasoService = PasoService;
            _HostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Paso = _PasoService.getByPk(ID);
            if (Paso == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Paso);
        }

        [HttpPost]
        public IActionResult savePaso()
        {
            try
            {
                bool finalizar = false;
                string json = Request.Form["resultados"];
                int idTramite = int.Parse(Request.Form["idTramite"]);
                int idPaso = int.Parse(Request.Form["idPaso"]);
                string cuit = Request.Form["cuit"];
                string cuitrepresentado = Request.Form["cuitrepresentado"];
                if (!string.IsNullOrEmpty(Request.Form["finaliza"]))
                { finalizar = true; }
                dynamic objeto = JsonConvert.DeserializeObject(json);

                Paso objPaso = Entities.Paso.getByPk(idPaso);

                Entities.Tramites objTramites = new Entities.Tramites();
                objTramites.id_tramite = idTramite;
                objTramites.cuit = cuit;
                objTramites.cuit_representado = cuitrepresentado;
                objTramites.fecha = DateTime.Now;
                objTramites.paso_actual = idPaso;
                objTramites.id_oficina = objPaso.proxima_oficina;

                int idTramites = Entities.Tramites.insert(objTramites);
                int i = 0;
                int id_ingreso_paso = 0;
                string nombre_ingreso_paso = string.Empty;
                foreach (var item in objeto)
                {
                    Entities.Pasos objPasos = new Entities.Pasos();
                    if (id_ingreso_paso != item.id_ingreso_paso.Value)
                    {
                        id_ingreso_paso = Convert.ToInt32(item.id_ingreso_paso.Value);
                        nombre_ingreso_paso = Entities.ingresos_x_paso.getNombreByPk(id_ingreso_paso);
                    }
                    objPasos.id_tramites = idTramites;
                    objPasos.id_paso = idPaso;
                    objPasos.orden_paso = Convert.ToInt32(item.orden.Value);
                    objPasos.id_ingreso_paso = id_ingreso_paso;
                    objPasos.orden_ingreso_paso = Convert.ToInt32(item.orden.Value);
                    objPasos.nombre_ingreso_paso = nombre_ingreso_paso;
                    objPasos.row = Convert.ToInt32(item.row.Value);
                    objPasos.col = Convert.ToInt32(item.col.Value);
                    objPasos.id_formulario = Convert.ToInt32(item.id_formulario.Value);
                    objPasos.id_adjunto = Convert.ToInt32(item.id_adjunto.Value);
                    objPasos.id_ddjj = Convert.ToInt32(item.id_ddjj.Value);
                    int idPasos = Entities.Pasos.insert(objPasos);
                    if (item.id_ddjj != 0)
                    {
                        Entities.Ddjjs objDDJJS = new Entities.Ddjjs();
                        objDDJJS.id = Convert.ToInt32(item.objDDJJ.id.Value);
                        objDDJJS.ddjj = item.objDDJJ.texto.Value;
                        objDDJJS.id_pasos = Convert.ToInt32(idPasos);
                        Entities.Ddjjs.insert(objDDJJS);
                    }
                    if (item.id_formulario != 0)
                    {
                        Entities.Formularios objFormulario = new Entities.Formularios();
                        objFormulario.id_formulario = Convert.ToInt32(item.objFormulario.id.Value);
                        objFormulario.nombre = item.objFormulario.nombre.Value;
                        objFormulario.descripcion = item.objFormulario.descripcion.Value;
                        objFormulario.id_pasos = idPasos;
                        int idForm = Entities.Formularios.insert(objFormulario);
                        foreach (var item2 in item.objFormulario.lstCampos)
                        {
                            Entities.Respuesta_formulario objRespuesta = new Entities.Respuesta_formulario();
                            objRespuesta.id_formularios = idForm;
                            objRespuesta.nombre_campo = item2.nombre.Value;
                            objRespuesta.id_tipo_campo = Convert.ToInt32(item2.id_tipo_campo.Value);
                            objRespuesta.etiqueta_campo = item2.etiqueta.Value;
                            switch (objRespuesta.id_tipo_campo)
                            {
                                case 1:
                                    objRespuesta.respuesta_usuario = item2.ingreso_usuario.Value;
                                    break;
                                case 2:
                                    objRespuesta.respuesta_usuario = item2.ingreso_usuario.Value;
                                    break;
                                case 3:
                                    objRespuesta.respuesta_usuario = Convert.ToString(item2.ingreso_usuario.Value);
                                    break;
                                case 4:
                                    objRespuesta.respuesta_usuario = item2.ingreso_usuario.Value;
                                    break;
                                case 5:
                                    objRespuesta.respuesta_usuario = item2.ingreso_usuario.Value;
                                    break;
                                case 6:
                                    objRespuesta.respuesta_usuario = Convert.ToString(item2.ingreso_usuario.Value);
                                    break;
                                case 7:
                                    objRespuesta.respuesta_usuario = Convert.ToString(item2.ingreso_usuario.Value);
                                    break;
                                case 8:
                                    objRespuesta.respuesta_usuario = Convert.ToString(item2.ingreso_usuario.Value);
                                    break;
                                case 9:
                                    objRespuesta.respuesta_usuario = JsonConvert.SerializeObject(
                                        item2.ingreso_usuario);
                                    break;
                                case 14:
                                    objRespuesta.respuesta_usuario = Convert.ToString(item2.ingreso_usuario.Value);
                                    break;
                                default:
                                    break;
                            }


                            objRespuesta.orden = Convert.ToInt32(item2.orden.Value);
                            Entities.Respuesta_formulario.insert(objRespuesta);
                        }
                    }
                    if (item.id_adjunto != 0)
                    {
                        Entities.Adjuntos objAdjunto = new Entities.Adjuntos();
                        objAdjunto.id = Convert.ToInt32(item.objAdjunto.id.Value);
                        objAdjunto.nombre = item.objAdjunto.etiqueta.Value;
                        objAdjunto.id_pasos = idPasos;
                        if (item.objAdjunto.multiple.Value)
                        {
                            string jsonString = item.objAdjunto.ingreso_usuario.ToString();
                            objAdjunto.archivo = jsonString;
                        }
                        else
                        {
                            objAdjunto.archivo = item.objAdjunto.ingreso_usuario.Value;
                        }
                        objAdjunto.extenciones_aceptadas = item.objAdjunto.extenciones_aceptadas.Value;
                        objAdjunto.multiple = item.objAdjunto.multiple.Value;
                        Entities.Adjuntos.insert(objAdjunto);
                    }
                }
                
                Entities.Movimiento_tramites objMov = new Movimiento_tramites();
                objMov.fecha = DateTime.Now;
                objMov.cuit = cuit;
                objMov.accion = "INICIO";
                objMov.en_vecino = true;
                objMov.id_tramites = idTramites;
                objMov.cod_oficina_destino = objPaso.proxima_oficina;
                Entities.Movimiento_tramites.insert(objMov);
                //if (objeto.es_final)
                //{
                //    //Entities.Tramites.finalizar_rechazar()
                //}

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpPost]
        public IActionResult savePasoMunicipal()
        {
            try
            {
                string json = Request.Form["resultados"];
                int idTramites = int.Parse(Request.Form["idTramites"]);
                int idPaso = int.Parse(Request.Form["idPaso"]);
                string cuit = Request.Form["cuit"];
                string estado = Request.Form["estado"];
                string cod_usuario = Request.Form["cod_usuario"];
                Paso objPaso = Entities.Paso.getByPk(idPaso);
                dynamic objeto = JsonConvert.DeserializeObject(json);
                Entities.Pasos objPasos = new Entities.Pasos();
                int id_ingreso_paso = 0;

                for (var i = 0; i < objeto.lstIngresos[0].lstContenido.Count; i++)
                {
                    objPasos.id_tramites = idTramites;
                    objPasos.id_paso = idPaso;
                    objPasos.orden_paso = Convert.ToInt32(objeto.lstIngresos[0].lstContenido[i].orden);
                    objPasos.id_ingreso_paso = id_ingreso_paso;
                    objPasos.orden_ingreso_paso = Convert.ToInt32(objeto.lstIngresos[0].lstContenido[i].orden);
                    objPasos.nombre_ingreso_paso = objPaso.nombre;
                    objPasos.row = Convert.ToInt32(objeto.lstIngresos[0].lstContenido[i].row);
                    objPasos.col = Convert.ToInt32(objeto.lstIngresos[0].lstContenido[i].col);
                    objPasos.id_formulario = Convert.ToInt32(objeto.lstIngresos[0].lstContenido[i].id_formulario);
                    objPasos.id_adjunto = Convert.ToInt32(objeto.lstIngresos[0].lstContenido[i].id_adjunto);
                    objPasos.id_ddjj = Convert.ToInt32(objeto.lstIngresos[0].lstContenido[i].id_ddjj);
                    int idPasos = Entities.Pasos.insert(objPasos);
                    if (objeto.lstIngresos[0].lstContenido[i].id_ddjj != 0)
                    {
                        Entities.Ddjjs objDDJJS = new Entities.Ddjjs();
                        objDDJJS.id = Convert.ToInt32(objeto.lstIngresos[0].lstContenido[i].objDDJJ.id.Value);
                        objDDJJS.ddjj = objeto.lstIngresos[0].lstContenido[i].objDDJJ.texto.Value;
                        objDDJJS.id_pasos = Convert.ToInt32(idPasos);
                        Entities.Ddjjs.insert(objDDJJS);
                    }
                    if (objeto.lstIngresos[0].lstContenido[i].id_formulario != 0)
                    {
                        Entities.Formularios objFormulario = new Entities.Formularios();
                        objFormulario.id_formulario = Convert.ToInt32(objeto.lstIngresos[0].lstContenido[i].objFormulario.id.Value);
                        objFormulario.nombre = objeto.lstIngresos[0].lstContenido[i].objFormulario.nombre.Value;
                        objFormulario.descripcion = objeto.lstIngresos[0].lstContenido[i].objFormulario.descripcion.Value;
                        objFormulario.id_pasos = idPasos;
                        int idForm = Entities.Formularios.insert(objFormulario);
                        foreach (var item2 in objeto.lstIngresos[0].lstContenido[i].objFormulario.lstCampos)
                        {
                            Entities.Respuesta_formulario objRespuesta = new Entities.Respuesta_formulario();
                            objRespuesta.id_formularios = idForm;
                            objRespuesta.nombre_campo = item2.nombre.Value;
                            objRespuesta.id_tipo_campo = Convert.ToInt32(item2.id_tipo_campo.Value);
                            objRespuesta.etiqueta_campo = item2.etiqueta.Value;
                            switch (objRespuesta.id_tipo_campo)
                            {
                                case 1:
                                    objRespuesta.respuesta_usuario = item2.ingreso_usuario.Value;
                                    break;
                                case 2:
                                    objRespuesta.respuesta_usuario = item2.ingreso_usuario.Value;
                                    break;
                                case 3:
                                    objRespuesta.respuesta_usuario = Convert.ToString(item2.ingreso_usuario.Value);
                                    break;
                                case 4:
                                    objRespuesta.respuesta_usuario = item2.ingreso_usuario.Value;
                                    break;
                                case 5:
                                    objRespuesta.respuesta_usuario = item2.ingreso_usuario.Value;
                                    break;
                                case 6:
                                    objRespuesta.respuesta_usuario = Convert.ToString(item2.ingreso_usuario.Value);
                                    break;
                                case 7:
                                    objRespuesta.respuesta_usuario = Convert.ToString(item2.ingreso_usuario.Value);
                                    break;
                                case 8:
                                    objRespuesta.respuesta_usuario = Convert.ToString(item2.ingreso_usuario.Value);
                                    break;
                                case 9:
                                    objRespuesta.respuesta_usuario = JsonConvert.SerializeObject(
                                        item2.ingreso_usuario);
                                    break;
                                case 14:
                                    objRespuesta.respuesta_usuario = Convert.ToString(item2.ingreso_usuario.Value);
                                    break;
                                default:
                                    break;
                            }


                            objRespuesta.orden = Convert.ToInt32(item2.orden.Value);
                            Entities.Respuesta_formulario.insert(objRespuesta);
                        }
                    }
                    if (objeto.lstIngresos[0].lstContenido[i].id_adjunto != 0)
                    {
                        Entities.Adjuntos objAdjunto = new Entities.Adjuntos();
                        objAdjunto.id = Convert.ToInt32(objeto.lstIngresos[0].lstContenido[i].objAdjunto.id.Value);
                        objAdjunto.nombre = objeto.lstIngresos[0].lstContenido[i].objAdjunto.etiqueta.Value;
                        objAdjunto.id_pasos = idPasos;
                        if (objeto.lstIngresos[0].lstContenido[i].objAdjunto.multiple.Value)
                        {
                            string jsonString = objeto.lstIngresos[0].lstContenido[i].objAdjunto.ingreso_usuario.ToString();
                            objAdjunto.archivo = jsonString;
                        }
                        else
                        {
                            objAdjunto.archivo = objeto.lstIngresos[0].lstContenido[i].objAdjunto.ingreso_usuario.Value;
                        }
                        objAdjunto.extenciones_aceptadas = objeto.lstIngresos[0].lstContenido[i].objAdjunto.extenciones_aceptadas.Value;
                        objAdjunto.multiple = objeto.lstIngresos[0].lstContenido[i].objAdjunto.multiple.Value;
                        Entities.Adjuntos.insert(objAdjunto);
                    }
                }

                

                if (objPaso.es_final)
                {
                    Entities.Tramites.finalizar_rechazar(idTramites, int.Parse(estado));
                    string accion = "";
                    switch (estado)
                    {
                        case "3":
                            accion = "RECHAZA";
                            break;
                        case "4":
                            accion = "APRUEBA";
                            break;
                        default:
                            break;
                    }
                    Entities.Movimiento_tramites objMov = new Movimiento_tramites();
                    objMov.fecha = DateTime.Now;
                    objMov.accion = accion;
                    objMov.en_vecino = false;
                    objMov.id_tramites = idTramites;
                    objMov.destino_vecino = true;
                    objMov.id_oficina = objPaso.id_oficina;
                    objMov.cod_usuario = int.Parse(cod_usuario);
                    Entities.Movimiento_tramites.insert(objMov);
                }
                else {
                    Entities.Tramites.mover(idTramites, objPaso.id, 
                        objPaso.id_oficina, objPaso.proxima_oficina);
                    Entities.Movimiento_tramites objMov = new Movimiento_tramites();
                    objMov.fecha = DateTime.Now;
                    objMov.accion = "PROCESA";
                    objMov.en_vecino = false;
                    objMov.id_tramites = idTramites;
                    objMov.destino_vecino = true;
                    objMov.id_oficina = objPaso.id_oficina;
                    objMov.cod_oficina_destino = objPaso.proxima_oficina;
                    objMov.cod_usuario = int.Parse(cod_usuario);
                    Entities.Movimiento_tramites.insert(objMov);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        public IActionResult read(int idTramite)
        {
            var Paso = _PasoService.read(idTramite);
            if (Paso == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Paso);
        }
        [HttpGet]
        public IActionResult readBackEnd(int idTramite)
        {
            var Paso = _PasoService.readBackEnd(idTramite);
            if (Paso == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Paso);
        }
        [HttpPost]
        public IActionResult insert(PasoModel obj)
        {
            try
            {
                _PasoService.insert(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult update(PasoModel obj)
        {
            try
            {
                _PasoService.update(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

