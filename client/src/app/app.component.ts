import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../enviroment/enviroment';
import { Product } from './shared/Models/Product';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  constructor(){

  }
  ngOnInit(): void {
  }


  title = 'client';
}
