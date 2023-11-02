using System;
using System.Collections.Generic;

namespace WorldCitiesClass;

public partial class Country
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Iso2 { get; set; }

    public string? Iso3 { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
