import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.html',
})
export class Cart {
  constructor(private router: Router) {}

  goToRouter(navigate: string) {
      this.router.navigate([navigate]);
  }
}
