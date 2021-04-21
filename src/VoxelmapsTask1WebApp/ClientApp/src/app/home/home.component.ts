import { Component, OnInit, AfterViewInit } from '@angular/core';
import { VoxelmapMapService } from '../services/voxelmap-map.service';
import { environment } from '../../environments/environment';
import * as L from 'leaflet';
import { Global, CovidServiceResponse, Country, CovidResponse, Feature } from '../models/covid-service-response';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit, AfterViewInit {
  private map: any;
  public hasLoaded = false;
  public global: Global = new Global();
  constructor(private mapService: VoxelmapMapService) { }


  ngOnInit() {
  }

  ngAfterViewInit(): void {
    this.initMap();
    this.GetPanelInfo();
   
    
  }

  private initMap() {
    this.map = L.map('map').setView([18.979026, 321.783834], 5);
    const tiles = L.tileLayer(environment.leafetTiles, {
      maxZoom: 15,
      attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    });
    tiles.addTo(this.map);
   
  }

  GetPanelInfo() {
    this.mapService.GetCovidInfonew().subscribe((r: CovidResponse) => {

      console.log(r.features);

      this.addMarkers(r.features);

    });
  }

  private addMarkers(countries: Array<Feature>): void {

    this.mapService.addMarkers(this.map, countries);

  }
}
