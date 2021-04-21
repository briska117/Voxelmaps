import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VoxelmapRequestService } from './voxelmap-request.service';
import { CovidServiceResponse, Country, Feature } from '../models/covid-service-response';
import { HttpClient } from '@angular/common/http';
import * as L from 'leaflet';
import { environment } from '../../environments/environment';
import { CountryInfo } from './CountryConst';

@Injectable({
  providedIn: 'root'
})
export class VoxelmapMapService {

  public url: string = "";
  constructor(private request: VoxelmapRequestService, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  public addMarkers(map: L.map, countries: Array<Feature>){
    countries.map((c: Feature) => {

      if (c.attributes.lat != undefined) {

        const marker = L.marker([c.attributes.lat, c.attributes.long]).addTo(map);
        marker.bindPopup(`<p>${c.attributes.countryRegion}, ${c.attributes.isO3}</p><br/>
          <p>Total Case Confirmed: ${c.attributes.confirmed}</p><br/>
          <p>Total Deaths for COVID-19: ${c.attributes.deaths}</p><br/>
          <p>Total Recovered: ${c.attributes.recovered}</p><br/>
          `).openPopup();
      } else {
        console.log(c.attributes);
      }
            
          
        
      })
    
  }

  
  GetAllCountries(){
    return CountryInfo;
  }

  GetCovidInfo(): Observable<any> {
    return this.request.getServer(environment.covidAPI);
  }

  GetCovidInfonew(): Observable<any> {
    return this.request.getServer(this.url + 'weatherforecast/Covid');
  }


}
