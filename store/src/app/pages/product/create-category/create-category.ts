import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.html',
})
export class CreateCategory {
  constructor(private router: Router) {}

  goToRouter(navigate: string) {
      this.router.navigate([navigate]);
  }
}
