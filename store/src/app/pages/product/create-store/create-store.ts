import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '../../../services/store';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-create-store',
  templateUrl: './create-store.html',
  imports: [CommonModule],
})
export class CreateStore {
  public stores: any[] = [];
  public storeID: number | undefined | null;
  
  constructor(
    private router: Router,
    private storeService: Store
  ) {}

  ngOnInit() {
    this.getAllStores();
  }

  goToRouter(navigate: string) {
    this.router.navigate([navigate]);
  }

  getAllStores() {
    this.storeService.getAll()
    .subscribe((response: any) => {
      this.stores = response;
    }, (error) => {
      console.error('Error fetching stores:', error);
    });
  }

  addStore() {
    const newStore = {
      nombre: (document.getElementById('nombreTienda') as HTMLInputElement).value,
      direccion: (document.getElementById('direccion') as HTMLInputElement).value,
    };

    this.storeService.create(newStore)
    .subscribe(() => {
      (document.getElementById('nombreTienda') as HTMLInputElement).value = '';
      (document.getElementById('direccion') as HTMLInputElement).value = '';
      this.getAllStores();
    }, (error) => {
      console.error('Error creating store:', error);
    });
  }

  deleteStore(id: number) {
    this.storeService.delete(id)
    .subscribe(() => {
      this.getAllStores();
    }, (error) => {
      console.error('Error deleting store:', error);
    });
  }

  editStore() {
    const newStore = {
      id: this.storeID,
      nombre: (document.getElementById('nombreTienda') as HTMLInputElement).value,
      direccion: (document.getElementById('direccion') as HTMLInputElement).value,
    };
    
    this.storeService.update(newStore)
    .subscribe(() => {
      this.storeID = null;
      (document.getElementById('nombreTienda') as HTMLInputElement).value = '';
      (document.getElementById('direccion') as HTMLInputElement).value = '';
      this.getAllStores();
      console.log(newStore);
    }, (error) => {
      console.error('Error added store:', error);
    });
  }

  getStoreById(id: number) {
    let store = this.stores.find(store => store.id === id);
    (document.getElementById('nombreTienda') as HTMLInputElement).value = store.nombre;
    (document.getElementById('direccion') as HTMLInputElement).value = store.direccion;
    this.storeID = store.id;
  }

  saveChanges() {
    if (this.storeID) {
      this.editStore();
    } else {
      this.addStore();
    }
  }
}
