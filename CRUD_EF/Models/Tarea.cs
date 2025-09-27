using System;
using System.Collections.Generic;

namespace CRUD_EF.Models;

public partial class Tarea
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public bool? Estado { get; set; }
}
