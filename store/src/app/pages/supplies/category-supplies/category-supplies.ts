import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CategorySupplies } from '../../../services/category_insumo';

@Component({
  selector: 'app-category-supplies',
  templateUrl: './category-supplies.html',
  imports: [CommonModule],
})
export class CategorySupplie {
  public category_supplies: any[] = [];
  public categorySupplieID: number | undefined | null;

  constructor(
    private router: Router,
    private categorySupplieService: CategorySupplies
  ) {}

  ngOnInit() {
    this.getAllCategorySupplies();
  }

  goToRouter(navigate: string) {
    this.router.navigate([navigate]);
  }

  getAllCategorySupplies() {
    this.categorySupplieService.getAll()
    .subscribe((response: any) => {
      this.category_supplies = response;
    }, (error) => {
      console.error('Error fetching category_supplies:', error);
    });
  }

  //

  deleteCategorySupplie(id: number) {
    this.categorySupplieService.delete(id)
    .subscribe(() => {
      this.getAllCategorySupplies();
    }, (error) => {
      console.error('Error deleting category:', error);
    });
  }

  addCategorySupplie() {
    const newCategory = {
      nombre: (document.getElementById('nombreCategoria') as HTMLInputElement).value,
      emoji: (document.getElementById('emoji') as HTMLInputElement).value,
    };

    this.categorySupplieService.create(newCategory)
    .subscribe(() => {
      (document.getElementById('nombreCategoria') as HTMLInputElement).value = '';
      (document.getElementById('emoji') as HTMLInputElement).value = '';
      this.getAllCategorySupplies();
    }, (error) => {
      console.error('Error creating category:', error);
    });
  }

  editCategorySupplie() {
    const newCategory = {
      id: this.categorySupplieID,
      nombre: (document.getElementById('nombreCategoria') as HTMLInputElement).value,
      emoji: (document.getElementById('emoji') as HTMLInputElement).value,
    };

    this.categorySupplieService.update(newCategory)
    .subscribe(() => {
      this.categorySupplieID = null;
      (document.getElementById('nombreCategoria') as HTMLInputElement).value = '';
      (document.getElementById('emoji') as HTMLInputElement).value = '';
      this.getAllCategorySupplies();
    }, (error) => {
      console.error('Error creating category:', error);
    });
  }

  getCategorySupplieById(id: number) {
    let category_supplie = this.category_supplies.find(category_supplie => category_supplie.id === id);
    console.log(category_supplie);

    (document.getElementById('nombreCategoria') as HTMLInputElement).value = category_supplie.nombre;
    (document.getElementById('emoji') as HTMLInputElement).value = category_supplie.emoji;
    this.categorySupplieID = category_supplie.id;
  }

  saveChanges() {
    if (this.categorySupplieID) {
      this.editCategorySupplie();
    } else {
      this.addCategorySupplie();
    }
  }
}
