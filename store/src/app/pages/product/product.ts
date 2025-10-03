import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.html',
})
export class Product {
  constructor(private router: Router) {}

    goToRouter(navigate: string) {
        this.router.navigate([navigate]);
    }
}
