import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.html',
})
export class Register {
    constructor(private router: Router) {}

    goToRouter(navigate: string) {
        this.router.navigate([navigate]);
    }
}
