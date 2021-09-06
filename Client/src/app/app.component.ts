import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { IPagination } from './models/IPagination';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Client';
  products: IProduct[];
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http
      .get('https://localhost:5001/api/products?pageSize=50')
      .subscribe((response: IPagination) => {
        // console.l;
        console.log(response.data);
        this.products = response.data;
      });
  }
}
