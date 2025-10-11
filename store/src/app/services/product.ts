import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environment/config.environment';

@Injectable({
  providedIn: 'root'
})
export class Product {
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  getAll() {
    let url = `${environment.backendUrl}/Producto/listar`;
    return this.http.get(url, this.httpOptions);
  }
  
  create(data:any) {
    let url = `${environment.backendUrl}/Producto/guardar`;
    return this.http.post(url, data, this.httpOptions);
  }

  update(data:any) {
    let url = `${environment.backendUrl}/Producto/actualizar/${data.id}`;
    return this.http.put(url, data, this.httpOptions);
  }

  delete(id:number) {
    let url = `${environment.backendUrl}/Producto/eliminar/${id}`;
    return this.http.delete(url, this.httpOptions);
  }
}
