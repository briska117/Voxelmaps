
export class CovidServiceResponse {
  ID: string
  Message: string
  Global: Global
  Countries: Country[]
  Date: string
}

export class Global {
  NewConfirmed: number
  TotalConfirmed: number
  NewDeaths: number
  TotalDeaths: number
  NewRecovered: number
  TotalRecovered: number
  Date: string
}

export class Country {
  ID: string
  Country: string
  CountryCode: string
  Slug: string
  NewConfirmed: number
  TotalConfirmed: number
  NewDeaths: number
  TotalDeaths: number
  NewRecovered: number
  TotalRecovered: number
  Date: string
  Premium: Premium
}

export class Premium { }

