using System;
using System.Collections.Generic;

namespace WorldCitiesClass;

public partial class City
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public int? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    public int Population { get; set; }
}
