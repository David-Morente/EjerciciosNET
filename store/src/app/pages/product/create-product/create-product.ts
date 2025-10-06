import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.html',
})
export class CreateProduct {
  constructor(private router: Router) {}

  goToRouter(navigate: string) {
      this.router.navigate([navigate]);
  }
}
