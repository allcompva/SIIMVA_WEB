﻿using CryptoManager.Clases;
using MOTOR_WORKFLOW.Entities.CIDI;
using MOTOR_WORKFLOW.Entities.CIDI.Documentos;
using Newtonsoft.Json;

namespace MOTOR_WORKFLOW.Services.CIDI
{
    public class UsuariosService : IUsuariosServices
    {
        public string ObtenerUsuario(string HashCookie)
        {
            try
            {
                Entities.CIDI.Entrada entrada = new Entities.CIDI.Entrada();
                entrada.IdAplicacion = Entities.CIDI.Config.CiDiIdAplicacion;
                entrada.Contrasenia = Entities.CIDI.Config.CiDiPassAplicacion;
                entrada.HashCookie = HashCookie;
                entrada.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                entrada.TokenValue = Entities.CIDI.Config.ObtenerToken_SHA1(entrada.TimeStamp);

                Entities.CIDI.Usuario Usuario = Entities.CIDI.Config.LlamarWebAPI<Entities.CIDI.Entrada,
                    Entities.CIDI.Usuario>(Entities.CIDI.APICuenta.Usuario.Obtener_Usuario_Basicos_Domicilio, entrada);
                Usuario.foto = TraerFotoPerfil(HashCookie, Usuario.CUIL);
                return JsonConvert.SerializeObject(Usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entities.CIDI.Usuario ObtenerUsuario2(string HashCookie)
        {
            try
            {
                Entities.CIDI.Entrada entrada = new Entities.CIDI.Entrada();
                entrada.IdAplicacion = Entities.CIDI.Config.CiDiIdAplicacion;
                entrada.Contrasenia = Entities.CIDI.Config.CiDiPassAplicacion;
                entrada.HashCookie = HashCookie;
                entrada.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                entrada.TokenValue = Entities.CIDI.Config.ObtenerToken_SHA1(entrada.TimeStamp);

                Entities.CIDI.Usuario Usuario = Entities.CIDI.Config.LlamarWebAPI<Entities.CIDI.Entrada,
                    Entities.CIDI.Usuario>(Entities.CIDI.APICuenta.Usuario.Obtener_Usuario_Basicos_Domicilio, entrada);
                //Usuario.foto = TraerFotoPerfil(HashCookie, Usuario.CUIL);
                return Usuario;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string TraerFotoPerfil(string hash, string cuit)
        {
            string ret = string.Empty;
            Entities.CIDI.Documentos.Entrada entrada = new Entities.CIDI.Documentos.Entrada();
            entrada.IdAplicacion = Entities.CIDI.Documentos.Config.CiDiIdAplicacion;
            entrada.Contrasenia = Entities.CIDI.Documentos.Config.CiDiPassAplicacion;
            entrada.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            entrada.TokenValue = Entities.CIDI.Documentos.Config.ObtenerToken_SHA512(entrada.TimeStamp);
            entrada.HashCookie = hash;
            entrada.Cuil = cuit;
            RespuestaDoc respuesta = Entities.CIDI.Documentos.Config.LlamarWebAPI<Entities.CIDI.Documentos.Entrada, RespuestaDoc>(
                Entities.CIDI.Documentos.APIDocumentacion.Documentacion.Obtener_Foto_Perfil, entrada);

            if (respuesta.Resultado == Entities.CIDI.Documentos.Config.CiDi_OK)
            {
                //Desencriptado de la Documentación
                CryptoHash objCryptoHash = new CryptoManager.Clases.CryptoHash();
                String mensaje = String.Empty;

                respuesta.Documentacion.Imagen = objCryptoHash.Descifrar_Datos(respuesta.Documentacion.Imagen, out mensaje);

                if (String.IsNullOrEmpty(mensaje))
                {
                    ret = MostrarImagen(respuesta);
                }
            }
            return ret;
        }
        private string MostrarImagen(RespuestaDoc Respuesta)
        {
            string ext = Respuesta.Documentacion.Extension.ToUpper();
            string[] FormatosPermitidos = new String[] { "JPG", "JPEG", "PNG", "BMP", "GIF", "PDF", "DOC", "DOCX", "XLS", "XLSX", "TXT" };
            string respuesta = string.Empty;

            if (Array.IndexOf(FormatosPermitidos, ext) >= 0)
            {
                if (ext != "PDF")
                {
                    string ImgVistaPrevia = Convert.ToBase64String(Respuesta.Documentacion.Imagen, 0, Respuesta.Documentacion.Imagen.Length);
                    respuesta = "data:image/" + ext + ";base64," + ImgVistaPrevia;
                }
            }
            return respuesta;
        }

        string IUsuariosServices.ObtenerUsuario(string HashCookie)
        {
            throw new NotImplementedException();
        }
    }
}
