import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from '../../../services/category';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.html',
  imports: [CommonModule],
})
export class CreateCategory {
  public categories: any[] = [];
  public categoryID: number | undefined | null;

  constructor(
    private router: Router,
    private categoryService: Category
  ) {}

  ngOnInit() {
    this.getAllCategories();
  }

  goToRouter(navigate: string) {
    this.router.navigate([navigate]);
  }

  getAllCategories() {
    this.categoryService.getAll()
    .subscribe((response: any) => {
      this.categories = response;
    }, (error) => {
      console.error('Error fetching categories:', error);
    });
  }

  deleteCategory(id: number) {
    this.categoryService.delete(id)
    .subscribe(() => {
      this.getAllCategories();
    }, (error) => {
      console.error('Error deleting category:', error);
    });
  }

  addCategory() {
    const newCategory = {
      nombre: (document.getElementById('nombreCategoria') as HTMLInputElement).value,
      emoji: (document.getElementById('emoji') as HTMLInputElement).value,
    };

    this.categoryService.create(newCategory)
    .subscribe(() => {
      (document.getElementById('nombreCategoria') as HTMLInputElement).value = '';
      (document.getElementById('emoji') as HTMLInputElement).value = '';
      this.getAllCategories();
    }, (error) => {
      console.error('Error creating category:', error);
    });
  }

  editCategory() {
    const newCategory = {
      id: this.categoryID,
      nombre: (document.getElementById('nombreCategoria') as HTMLInputElement).value,
      emoji: (document.getElementById('emoji') as HTMLInputElement).value,
    };

    this.categoryService.update(newCategory)
    .subscribe(() => {
      this.categoryID = null;
      (document.getElementById('nombreCategoria') as HTMLInputElement).value = '';
      (document.getElementById('emoji') as HTMLInputElement).value = '';
      this.getAllCategories();
    }, (error) => {
      console.error('Error creating category:', error);
    });
  }

  getCategoryById(id: number) {
    let category = this.categories.find(category => category.id === id);
    (document.getElementById('nombreCategoria') as HTMLInputElement).value = category.nombre;
    (document.getElementById('emoji') as HTMLInputElement).value = category.emoji;
    this.categoryID = category.id;
  }

  saveChanges() {
    if (this.categoryID) {
      this.editCategory();
    } else {
      this.addCategory();
    }
  }

}
