import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environment/config.environment';

@Injectable({
  providedIn: 'root'
})
export class Supplie {
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  getAll() {
    let url = `${environment.backendUrl}/Insumo/listar`;
    return this.http.get(url, this.httpOptions);
  }
  
  create(data:any) {
    let url = `${environment.backendUrl}/Insumo/guardar`;
    return this.http.post(url, data, this.httpOptions);
  }

  update(data:any) {
    let url = `${environment.backendUrl}/Insumo/actualizar/${data.id}`;
    return this.http.put(url, data, this.httpOptions);
  }

  delete(id:number) {
    let url = `${environment.backendUrl}/Insumo/eliminar/${id}`;
    return this.http.delete(url, this.httpOptions);
  }
}
