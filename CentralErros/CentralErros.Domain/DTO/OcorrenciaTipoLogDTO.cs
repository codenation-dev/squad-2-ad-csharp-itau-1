using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Domain.DTO
{
    public class OcorrenciaTipoLogDTO
    {
        public int IdTipoLog { get; set; }
        public string Descricao { get; set; }
        public int QtdeOcorrencia { get; set; }
    }
}
