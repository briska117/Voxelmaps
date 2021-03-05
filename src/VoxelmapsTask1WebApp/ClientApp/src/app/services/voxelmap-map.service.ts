import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VoxelmapRequestService } from './voxelmap-request.service';
import { CovidServiceResponse, Country } from '../models/covid-service-response';
import { HttpClient } from '@angular/common/http';
import * as L from 'leaflet';
import { environment } from '../../environments/environment';
import { CountryInfo } from './CountryConst';

@Injectable({
  providedIn: 'root'
})
export class VoxelmapMapService {
  constructor(private request: VoxelmapRequestService) { }

  public addMarkers(map: L.map, countries: Array<Country>){
    const countriesLatLong = this.GetAllCountries();
        countries.map((c: Country) => {
          const countryLatLong = countriesLatLong.find(con => con.country == c.CountryCode);
          if (countryLatLong !== undefined) {
            const marker = L.marker([countryLatLong.latitude, countryLatLong.longitude]).addTo(map);
            marker.bindPopup(`<p>${c.Country}, ${c.CountryCode}</p><br/>
          <p>Total Case Confirmed: ${c.TotalConfirmed}</p><br/>
          <p>Total Deaths for COVID-19: ${c.TotalDeaths}</p><br/>
          <p>Total Recovered: ${c.TotalRecovered}</p><br/>
          `).openPopup();
            
          }  
        
      })
    
  }

  
  GetAllCountries(){
    return CountryInfo;
  }

  GetCovidInfo(): Observable<any> {
    return this.request.getServer(environment.covidAPI);
  }


}
