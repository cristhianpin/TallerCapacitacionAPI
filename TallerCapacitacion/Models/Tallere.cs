using System;
using System.Collections.Generic;

namespace TallerCapacitacion.Models;

public partial class Tallere
{
    public int IdTaller { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime FechaInicio { get; set; }

    public int DuracionHoras { get; set; }

    public int CupoMaximo { get; set; }

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();
}
