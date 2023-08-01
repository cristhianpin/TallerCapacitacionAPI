using System;
using System.Collections.Generic;

namespace TallerCapacitacion.Models;

public partial class Asistencia
{
    public int IdAsistencia { get; set; }

    public int? IdInscripcion { get; set; }

    public DateTime FechaAsistencia { get; set; }

    public virtual Inscripcione? IdInscripcionNavigation { get; set; }
}
