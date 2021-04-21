
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

export class UniqueIdField {
  name: string;
  isSystemMaintained: boolean;
}

export class SpatialReference {
  wkid: number;
  latestWkid: number;
}

export class Field {
  name: string;
  type: string;
  alias: string;
  sqlType: string;
  length: number;
  domain?: any;
  defaultValue?: any;
}

export class Attributes {
  countryRegion: string;
  lat: string;
  long: string;
  confirmed: number;
  deaths: number;
  recovered?: number;
  uid: number;
  isO3: string;
}

export class Feature {
  attributes: Attributes;
}

export class CovidResponse {
  objectIdFieldName: string;
  uniqueIdField: UniqueIdField;
  globalIdFieldName: string;
  geometryType: string;
  spatialReference: SpatialReference;
  fields: Field[];
  features: Feature[];
}


