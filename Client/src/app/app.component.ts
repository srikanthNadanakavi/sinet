import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { BasketService } from './basket/basket.service';
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
  constructor(private basketService: BasketService) {}

  ngOnInit(): void {
    const basketId = localStorage.getItem('basket_id');

    if (basketId) {
      this.basketService.getBasket(basketId).subscribe(
        () => {
          console.log('Initil basket');
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }
}
