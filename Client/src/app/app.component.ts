import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { IPagination } from './shared/models/IPagination';
import { IProduct } from './shared/models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Client';
  products: IProduct[];
  constructor() {}

  ngOnInit(): void {}
}
