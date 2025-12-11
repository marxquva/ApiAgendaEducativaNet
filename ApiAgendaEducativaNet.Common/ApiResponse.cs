using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }     // Estado de la respuesta
        public string Message { get; set; }   // Mensaje para el cliente
        public T Data { get; set; }           // Carga útil

        public ApiResponse(T data, string message = "Operación realizada con éxito")
        {
            Success = true;
            Message = message;
            Data = data;
        }

        public ApiResponse(string message)
        {
            Success = false;
            Message = message;
            Data = default(T);
        }
    }
}

